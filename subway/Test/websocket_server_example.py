import websocket_server
import threading

def on_message(client, server, message):
    print(message)
    # Echo the received message back to the client
    server.send_message(client, message)

def on_new_client(client, server):
    print("New client connected")

if __name__ == "__main__":
    host = "localhost"  # specify the host
    port = 8080  # specify the port
    server = websocket_server.WebsocketServer(host=host,port=port)
    server.set_fn_message_received(on_message)
    server.set_fn_new_client(on_new_client)

    # Start the server in a separate thread
    server_thread = threading.Thread(target=server.run_forever)
    server_thread.daemon = True
    server_thread.start()

    print("WebSocket server is running. Listening for connections...")

    # Keep the main thread running
    while True:
        pass
