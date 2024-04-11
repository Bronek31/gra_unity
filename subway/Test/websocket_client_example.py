import websocket
import threading

def on_message(ws, message):
    print(message)

def on_error(ws, error):
    print(error)

def on_close(ws):
    print("Closing")

def on_open(ws):
    # Start a separate thread for user input
    threading.Thread(target=get_user_input, args=(ws,)).start()

def get_user_input(ws):
    while True:
        user_input = input("Enter direction (UP/DOWN/LEFT/RIGHT): ")
        if user_input.upper() in ["UP", "DOWN", "LEFT", "RIGHT"]:
            ws.send(user_input.upper())
        else:
            print("Invalid input. Please enter UP, DOWN, LEFT, or RIGHT.")

if __name__ == "__main__":
    websocket.enableTrace(True)
    ws = websocket.WebSocketApp("ws://localhost:8080/Auth",
                                on_message=on_message,
                                on_error=on_error,
                                on_close=on_close)
    ws.on_open = on_open
    ws.run_forever()
