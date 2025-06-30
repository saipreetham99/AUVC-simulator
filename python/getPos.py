from dataclasses import dataclass
from peaceful_pie.unity_comms import UnityComms

import argparse

@dataclass
class MyVector3:
    x: float
    y: float
    z: float



def run(args: argparse.Namespace)->None:
    unity_comms = UnityComms(port=args.port)
    # unity_comms.Say(message = args.message)
    res: MyVector3=   unity_comms.getPos(ResultClass = MyVector3)
    print(res)
    print(type(res))
    print(res.x)
    
    
    
   
if __name__=='__main__':
    parser = argparse.ArgumentParser(description='Say something to Unity.')
    # parser.add_argument('--message',type =str, default="Hello")
    parser.add_argument('--port',type =int, default=9000)
    args = parser.parse_args()
    run(args)