//********************************************************************************************
//Author: Sergiy Stoyan
//        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace Cliver
{
    abstract public class Operation
    {
        //public class AbortException : Exception
        //{
        //    public AbortException(bool show, Log.MessageType messageType, string message)
        //    {
        //        Show = show;
        //        MessageType = messageType;
        //    }

        //    readonly public bool Show;

        //    readonly public Log.MessageType MessageType = Log.MessageType.WARNING;
        //}

        public OperationStatus Run()
        {
            OperationStatus status = OperationStatus.Running;
            try
            {
                OnStart();
                Body();
                OnCompletion();
                status = OperationStatus.Completed;
            }
            catch (Exception e)
            {
                OnException(e);
                status = Aborting ? OperationStatus.Aborted : OperationStatus.Failed;
            }
            finally
            {
                OnFinally();
                Status = status;
            }
            return Status;
        }

        virtual protected void OnStart() { }

        virtual protected void OnCompletion() { }

        virtual protected void OnFinally() { }

        virtual protected void OnException(Exception e) { }

        protected abstract void Body();

        protected void AddAbortingActions(params Action[] actions)
        {
            if (Aborting)
                throw new Exception("Aborting");
            abortingActions.AddRange(actions);
        }
        List<Action> abortingActions = new List<Action>();

        public bool Abort(int timeoutMss)
        {
            Aborting = true;
            abortingActions.ForEach(a => a());
            return SleepRoutines.WaitForCondition(() => { return Status >= OperationStatus.Running; }, timeoutMss, 100);
        }
        protected bool Aborting { get; private set; } = false;

        public enum OperationStatus
        {
            Created,
            Running,
            Completed,
            Aborted,
            Failed
        }
        public OperationStatus Status { get; private set; } = OperationStatus.Created;

        async public Task RunAsync()
        {
            await Task.Run(Run);
        }

        async public Task<bool> AbortAsync(int timeoutMss)
        {
            return await Task.Run(() => { return Abort(timeoutMss); });
        }
    }
}