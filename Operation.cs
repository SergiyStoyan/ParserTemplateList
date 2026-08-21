////********************************************************************************************
////Author: Sergiy Stoyan
////        s.y.stoyan@gmail.com, sergiy.stoyan@outlook.com, stoyan@cliversoft.com
////        http://www.cliversoft.com
////********************************************************************************************
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.IO;
//using System.Text.RegularExpressions;
//using System.Text;
//using System.Threading.Tasks;

//namespace Cliver
//{
//    /// <summary>
//    /// !!!OperationController seems to be more practical.
//    /// As a base class provides:
//    /// - safely aborting of the operation;
//    /// - event entries;
//    /// - async methods;
//    /// </summary>
//    abstract public class Operation
//    {
//        public OperationStatus Perform()
//        {
//            OperationStatus status = OperationStatus.Running;
//            try
//            {
//                OnStart.ForEach(a => a());
//                Body();
//                OnCompletion.ForEach(a => a());
//                status = OperationStatus.Completed;
//            }
//            catch (Exception e)
//            {
//                status = Aborting ? OperationStatus.Aborted : OperationStatus.Failed;
//                OnException.ForEach(a => a(e));
//            }
//            finally
//            {
//                OnFinally.ForEach(a => a());
//                Status = status;
//            }
//            return Status;
//        }

//        readonly public List<Action> OnStart = new List<Action>();

//        readonly public List<Action> OnCompletion = new List<Action>();

//        readonly public List<Action> OnFinally = new List<Action>();

//        readonly public List<Action<Exception>> OnException = new List<Action<Exception>>();

//        abstract protected void Body();

//        public void AddAbortingActions(params Action[] actions)
//        {
//            if (Aborting)
//                throw new Exception("Aborting");
//            abortingActions.AddRange(actions);
//        }
//        List<Action> abortingActions = new List<Action>();

//        public bool Abort(int timeoutMss)
//        {
//            Aborting = true;
//            abortingActions.ForEach(a => a());
//            return SleepRoutines.WaitForCondition(() => { return Status >= OperationStatus.Running; }, timeoutMss, 100);
//        }
//        public bool Aborting { get; private set; } = false;

//        public enum OperationStatus
//        {
//            Created,
//            Running,
//            Completed,
//            Aborted,
//            Failed
//        }
//        public OperationStatus Status { get; private set; } = OperationStatus.Created;

//        async public Task<OperationStatus> PerformAsync()
//        {
//            return await Task.Run(Perform);
//        }

//        async public Task<bool> AbortAsync(int timeoutMss)
//        {
//            return await Task.Run(() => { return Abort(timeoutMss); });
//        }
//    }
//}