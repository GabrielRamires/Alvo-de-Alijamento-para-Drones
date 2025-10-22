Este projeto foi desenvolvido para a competição DronIFSC 2025 da Sepei 2025, mais especificamente para a prova de alijamento de carga.
Consiste em um sistema de alvo virtual dinâmico e ajustável, que se comunica em tempo real com a câmera do drone. 
O objetivo é fornecer uma referência visual precisa durante a fase de voo, permitindo que o piloto ou sistema autônomo realize a liberação da carga com maior precisão e confiabilidade.

Esse projeto também contém a leitura da telemetria em tempo real por HUDs no aplicativo, mas não é necessária para o funcionamento do aplicativo, use apenas se quiser mais informações do drone na tela.

Aqui vai o *MANUAL DE INSTRUÇÕES* de como usar o aplicativo:

COMO USAR O APLICATIVO DO ALVO DE ALIJAMENTO COM A TELEMETRIA:

ABRA O APLICATIVO DO MISSION PLANNER E CONECTE SUA TELEMETRIA. 

COM A TELEMETRIA LIGADA ENTRE EM SUA IDE QUE RODE PYTHON E RODE O CÓDIGO "mavlink_to_json_udp.py".
(Lembrando que essa parte é apenas se você quiser conectar a telemetria ao aplicativo)

↓↓↓(se você nao tiver telemetria no drone o manual começa a partir daqui)↓↓↓

CLIQUE NO APLICATIVO *ALVO DE ALIJAMENTO*.

Ao iniciar, estará na primeira câmera (câmera do seu notebook). Caso esteja conectada mais de uma câmera ao seu computador(câmera do drone), você deverá apertar a tecla 2
para acessar a segunda câmera.


A cruzeta estará inicialmente no centro da tela do seu computador, para movimentá-la use as teclas:

W - para cima.

A - para esquerda.

S - para baixo.

D - para direita.


Ao movimenta-la você pode usar o tecla a ENTER para fazê-la voltar à posição inicial. 

Caso queira mudar a posição inicial do aplicativo você deve pressionar na tecla P, fixando assim uma nova posição como inicial.

Caso necessite voltar à posição inicial padrão do aplicativo, pressione na tecla 0.

*CASO JÁ TENHA A COORDENADA ESPECÍFICA*

Aperte Tab e escreva o numero da coordenada x e y inteiro, exemplo (-300,200). 
Em caso de Bug da câmera desaparecer, clique no número que foi setado para abrir sua câmera, que ela reaparecerá.

