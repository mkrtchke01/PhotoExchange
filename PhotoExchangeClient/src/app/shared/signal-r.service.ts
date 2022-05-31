import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr'

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  constructor() { }

  hubConnection: signalR.HubConnection


  GetConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:7242/likes',{
      skipNegotiation:true,
      transport: signalR.HttpTransportType.WebSockets
    }).build();
    this.hubConnection.start().then(()=>
    {
      console.log('Hub started!');
    })
    .catch(err=>console.log('error'))
  }
  LikeHubServer(userName: string, postId: number){
    this.hubConnection.invoke("LikeHubServer", userName, postId);
  }
  askServerListener(){
    this.hubConnection.on("askServerResponse", (likesCount) => { likesCount});
  }
}
