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
    /// <summary>
    /// As a base class provides:
    /// - safely aborting of the operation;
    /// - event entries;
    /// - async methods;
    /// </summary>
    abstract public class Operation : OperationController
    {
        public Operation()
        {
            Operation = Body;
        }

        public virtual string Name { get { return GetType().Name; } }

        public abstract void Body();
    }
}