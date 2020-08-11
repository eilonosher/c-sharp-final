﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GamePlay.GamrServiceRef {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpponentDisconnectedFault", Namespace="http://schemas.datacontract.org/2004/07/GameService")]
    [System.SerializableAttribute()]
    public partial class OpponentDisconnectedFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MoveResult", Namespace="http://schemas.datacontract.org/2004/07/GameService")]
    public enum MoveResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        YouWon = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Draw = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        NotYourTurn = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        GameOn = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UnlegalMove = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        YouLose = 5,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GamrServiceRef.IGameService", CallbackContract=typeof(GamePlay.GamrServiceRef.IGameServiceCallback))]
    public interface IGameService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Register", ReplyAction="http://tempuri.org/IGameService/RegisterResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(GamePlay.GamrServiceRef.OpponentDisconnectedFault), Action="http://tempuri.org/IGameService/RegisterOpponentDisconnectedFaultFault", Name="OpponentDisconnectedFault", Namespace="http://schemas.datacontract.org/2004/07/GameService")]
        void Register(string user, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Register", ReplyAction="http://tempuri.org/IGameService/RegisterResponse")]
        System.Threading.Tasks.Task RegisterAsync(string user, string pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ReportMove", ReplyAction="http://tempuri.org/IGameService/ReportMoveResponse")]
        GamePlay.GamrServiceRef.MoveResult ReportMove(int location, string player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ReportMove", ReplyAction="http://tempuri.org/IGameService/ReportMoveResponse")]
        System.Threading.Tasks.Task<GamePlay.GamrServiceRef.MoveResult> ReportMoveAsync(int location, string player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Disconnect", ReplyAction="http://tempuri.org/IGameService/DisconnectResponse")]
        void Disconnect(string player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/Disconnect", ReplyAction="http://tempuri.org/IGameService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(string player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/StartGame", ReplyAction="http://tempuri.org/IGameService/StartGameResponse")]
        bool StartGame(string by, string player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/StartGame", ReplyAction="http://tempuri.org/IGameService/StartGameResponse")]
        System.Threading.Tasks.Task<bool> StartGameAsync(string by, string player);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/StartGameBetweenPlayers", ReplyAction="http://tempuri.org/IGameService/StartGameBetweenPlayersResponse")]
        void StartGameBetweenPlayers(string p1, string p2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/StartGameBetweenPlayers", ReplyAction="http://tempuri.org/IGameService/StartGameBetweenPlayersResponse")]
        System.Threading.Tasks.Task StartGameBetweenPlayersAsync(string p1, string p2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAvliableClients", ReplyAction="http://tempuri.org/IGameService/GetAvliableClientsResponse")]
        System.Collections.Generic.Dictionary<string, object> GetAvliableClients();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAvliableClients", ReplyAction="http://tempuri.org/IGameService/GetAvliableClientsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, object>> GetAvliableClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAvliableClientsForUser", ReplyAction="http://tempuri.org/IGameService/GetAvliableClientsForUserResponse")]
        System.Collections.Generic.Dictionary<string, object> GetAvliableClientsForUser(string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/GetAvliableClientsForUser", ReplyAction="http://tempuri.org/IGameService/GetAvliableClientsForUserResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, object>> GetAvliableClientsForUserAsync(string user);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/OtherPlayerDisconnected")]
        void OtherPlayerDisconnected(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/OtherPlayerStartedGame")]
        void OtherPlayerStartedGame(string user1, string user2);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/OtherPlayerMoved")]
        void OtherPlayerMoved(GamePlay.GamrServiceRef.MoveResult moveResult, int row, int col);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/StartGameUser")]
        void StartGameUser(string p1);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IGameService/OtherPlayerSignIn")]
        void OtherPlayerSignIn(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGameService/ConfirmGame", ReplyAction="http://tempuri.org/IGameService/ConfirmGameResponse")]
        bool ConfirmGame(string userToGame);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGameServiceChannel : GamePlay.GamrServiceRef.IGameService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GameServiceClient : System.ServiceModel.DuplexClientBase<GamePlay.GamrServiceRef.IGameService>, GamePlay.GamrServiceRef.IGameService {
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public GameServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void Register(string user, string pass) {
            base.Channel.Register(user, pass);
        }
        
        public System.Threading.Tasks.Task RegisterAsync(string user, string pass) {
            return base.Channel.RegisterAsync(user, pass);
        }
        
        public GamePlay.GamrServiceRef.MoveResult ReportMove(int location, string player) {
            return base.Channel.ReportMove(location, player);
        }
        
        public System.Threading.Tasks.Task<GamePlay.GamrServiceRef.MoveResult> ReportMoveAsync(int location, string player) {
            return base.Channel.ReportMoveAsync(location, player);
        }
        
        public void Disconnect(string player) {
            base.Channel.Disconnect(player);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(string player) {
            return base.Channel.DisconnectAsync(player);
        }
        
        public bool StartGame(string by, string player) {
            return base.Channel.StartGame(by, player);
        }
        
        public System.Threading.Tasks.Task<bool> StartGameAsync(string by, string player) {
            return base.Channel.StartGameAsync(by, player);
        }
        
        public void StartGameBetweenPlayers(string p1, string p2) {
            base.Channel.StartGameBetweenPlayers(p1, p2);
        }
        
        public System.Threading.Tasks.Task StartGameBetweenPlayersAsync(string p1, string p2) {
            return base.Channel.StartGameBetweenPlayersAsync(p1, p2);
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetAvliableClients() {
            return base.Channel.GetAvliableClients();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, object>> GetAvliableClientsAsync() {
            return base.Channel.GetAvliableClientsAsync();
        }
        
        public System.Collections.Generic.Dictionary<string, object> GetAvliableClientsForUser(string user) {
            return base.Channel.GetAvliableClientsForUser(user);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<string, object>> GetAvliableClientsForUserAsync(string user) {
            return base.Channel.GetAvliableClientsForUserAsync(user);
        }
    }
}
