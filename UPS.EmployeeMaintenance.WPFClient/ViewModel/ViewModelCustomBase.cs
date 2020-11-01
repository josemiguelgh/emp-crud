using System;
using System.Linq.Expressions;
using GalaSoft.MvvmLight.Messaging;
using UPS.EmployeeMaintenance.Dtos;

namespace UPS.EmployeeMaintenance.WPFClient.ViewModel
{
    public class ViewModelCustomBase<TViewModel> : ViewModelBase
    {
        protected string BuildCompositeErrorMessage(string errorMessage, string stackTrace)
        {
            return string.Format("Error = {0} // StackTrace = {1}", errorMessage, stackTrace);
        }

        protected void PropagateException(string errorMessage, string token)
        {
            var operationResult = new OperationResult<string> { Succeed = false, Message = errorMessage };
            Messenger.Default.Send(operationResult, token);
        }

        protected void PropagateMessage(string message, string token)
        {
            Messenger.Default.Send(message, token);
        }

        public void RaisePropertyChanged(Expression<Func<TViewModel, object>> propertyGetter)
        {
            RaisePropertyChanged(propertyGetter.GetPropertyNameString());
        }

    }
}