﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace UserMaintenance.ServiceUser {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceUser.IServiceUser")]
    public interface IServiceUser {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Show", ReplyAction="http://tempuri.org/IServiceUser/ShowResponse")]
        List<WcfService.Models.User> Show();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Show", ReplyAction="http://tempuri.org/IServiceUser/ShowResponse")]
        System.Threading.Tasks.Task<List<WcfService.Models.User>> ShowAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/ShowId", ReplyAction="http://tempuri.org/IServiceUser/ShowIdResponse")]
        WcfService.Models.User ShowId(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/ShowId", ReplyAction="http://tempuri.org/IServiceUser/ShowIdResponse")]
        System.Threading.Tasks.Task<WcfService.Models.User> ShowIdAsync(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Create", ReplyAction="http://tempuri.org/IServiceUser/CreateResponse")]
        int Create(WcfService.ModelsDto.UserCreateDto Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Create", ReplyAction="http://tempuri.org/IServiceUser/CreateResponse")]
        System.Threading.Tasks.Task<int> CreateAsync(WcfService.ModelsDto.UserCreateDto Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Update", ReplyAction="http://tempuri.org/IServiceUser/UpdateResponse")]
        int Update(WcfService.Models.User Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Update", ReplyAction="http://tempuri.org/IServiceUser/UpdateResponse")]
        System.Threading.Tasks.Task<int> UpdateAsync(WcfService.Models.User Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Delete", ReplyAction="http://tempuri.org/IServiceUser/DeleteResponse")]
        int Delete(int Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceUser/Delete", ReplyAction="http://tempuri.org/IServiceUser/DeleteResponse")]
        System.Threading.Tasks.Task<int> DeleteAsync(int Id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceUserChannel : UserMaintenance.ServiceUser.IServiceUser, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceUserClient : System.ServiceModel.ClientBase<UserMaintenance.ServiceUser.IServiceUser>, UserMaintenance.ServiceUser.IServiceUser {
        
        public ServiceUserClient() {
        }
        
        public ServiceUserClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceUserClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceUserClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceUserClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public List<WcfService.Models.User> Show() {
            return base.Channel.Show();
        }
        
        public System.Threading.Tasks.Task<List<WcfService.Models.User>> ShowAsync() {
            return base.Channel.ShowAsync();
        }
        
        public WcfService.Models.User ShowId(int Id) {
            return base.Channel.ShowId(Id);
        }
        
        public System.Threading.Tasks.Task<WcfService.Models.User> ShowIdAsync(int Id) {
            return base.Channel.ShowIdAsync(Id);
        }
        
        public int Create(WcfService.ModelsDto.UserCreateDto Model) {
            return base.Channel.Create(Model);
        }
        
        public System.Threading.Tasks.Task<int> CreateAsync(WcfService.ModelsDto.UserCreateDto Model) {
            return base.Channel.CreateAsync(Model);
        }
        
        public int Update(WcfService.Models.User Model) {
            return base.Channel.Update(Model);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAsync(WcfService.Models.User Model) {
            return base.Channel.UpdateAsync(Model);
        }
        
        public int Delete(int Id) {
            return base.Channel.Delete(Id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteAsync(int Id) {
            return base.Channel.DeleteAsync(Id);
        }
    }
}
