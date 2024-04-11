using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;
public class MyWebSocketServer : MonoBehaviour
{
    public static PlayerController playerControllerInstance; // Static reference to PlayerController instance
    public static bool is_client_connected = false;
    void Start()
    {
        Debug.Log("MyWebSocketServer Starting...");
        playerControllerInstance = FindObjectOfType<PlayerController>();
        var socket = new WebSocketServer("ws://localhost:8080"); //TODO this might need changing
        socket.AddWebSocketService<AuthBehaviour>("/Auth");
        socket.Start();
    }
}

public class AuthBehaviour : WebSocketBehavior
{

    protected override void OnOpen()
    {
        base.OnOpen();
        Debug.Log("WebSocket client connected");
        MyWebSocketServer.is_client_connected = true;
    }
    protected override void OnMessage(MessageEventArgs e)
    {
        var message = e.Data;
        Debug.Log("WebSocket message received: " + message);

        // Check the received message and invoke corresponding methods in PlayerController
        if (MyWebSocketServer.playerControllerInstance != null)
        {
            if (message == "LEFT")
            {
                MyWebSocketServer.playerControllerInstance.current_command = 4;
            }
            else if (message == "RIGHT")
            {
                MyWebSocketServer.playerControllerInstance.current_command = 3;

            }
            else if (message == "DOWN")
            {
                MyWebSocketServer.playerControllerInstance.current_command = 2;

            }
            else if (message == "UP")
            {
                MyWebSocketServer.playerControllerInstance.current_command = 1;

            }
            else
            {
                Debug.Log("Unsupported command received, not doing anything");
            }
        }
        else
        {
            Debug.Log("Player controller does not exist");
        }
    }
}
