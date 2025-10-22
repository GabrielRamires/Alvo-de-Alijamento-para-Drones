import json
import socket
from pymavlink import mavutil

# ====== CONFIG ======
MAVLINK_UDP_PORT = 14550
UNITY_IP = "127.0.0.1"
UNITY_PORT = 15000

# ====== CONEXÕES ======
master = mavutil.mavlink_connection(f'udp:127.0.0.1:{MAVLINK_UDP_PORT}')
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

print("Aguardando heartbeat do drone...")
master.wait_heartbeat()
print("Conectado ao drone!")

# ====== LOOP PRINCIPAL ======
try:
    while True:
        msg = master.recv_match(blocking=True)
        if not msg:
            continue

        try:
            if msg.get_type() == "ATTITUDE":
                yaw = msg.yaw * 180 / 3.14159  # rad → grau

            if msg.get_type() == "GLOBAL_POSITION_INT":
                data = {
                    "altitude": msg.relative_alt / 1000.0,
                    "yaw": yaw,
                    "latitude": msg.lat / 1e7,
                    "longitude": msg.lon / 1e7,
                    "groundspeed": msg.vx / 100.0
                }
                json_str = json.dumps(data)
                sock.sendto(json_str.encode('utf-8'), (UNITY_IP, UNITY_PORT))
                print(f"Enviado: {json_str}")

        except Exception as e:
            print(f"Erro ao processar mensagem: {e}")

except KeyboardInterrupt:
    print("Encerrando conexão...")
    sock.close()