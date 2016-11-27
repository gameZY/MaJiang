del /f /s /q D:\zhouhang\project\chessProject\chess\Assets\Scripts\lua\Define\proto\*.*

protoc --lua_out=D:/zhouhang/project/chessProject/chess/Assets/Scripts/lua/Define/proto --plugin=protoc-gen-lua="D:/zhouhang/project/netmessage/protoc-gen-lua/plugin/protoc-gen-lua.bat" Login.proto
protoc --lua_out=D:/zhouhang/project/chessProject/chess/Assets/Scripts/lua/Define/proto --plugin=protoc-gen-lua="D:/zhouhang/project/netmessage/protoc-gen-lua/plugin/protoc-gen-lua.bat" Pk.proto

protoc --python_out=D:/zhouhang/project/chessProject/server/game/core/proto --plugin=protoc-gen-lua="E:/protoc-gen-lua/plugin/protoc-gen-lua.bat" Login.proto
protoc --python_out=D:/zhouhang/project/chessProject/server/game/core/proto --plugin=protoc-gen-lua="E:/protoc-gen-lua/plugin/protoc-gen-lua.bat" Pk.proto

ren D:\zhouhang\project\chessProject\chess\Assets\Scripts\lua\Define\proto\*.lua *.txt
pause