#
# CMake Toolchain file for crosscompiling on arm64.
#
# This can be used when running cmake in the following way:
#  $ sudo apt-get install g++-aarch64-linux-gnu
#  $ cd build/
#  $ cmake .. -DCMAKE_TOOLCHAIN_FILE=../lzfse.musl-x64.cmake
#

# Target operating system name.
set(CMAKE_SYSTEM_NAME Linux)
set(CMAKE_SYSTEM_PROCESSOR x86_64)

# Name of C compiler.
set(CMAKE_C_COMPILER "musl-gcc")
set(CMAKE_CXX_COMPILER "musl-g++")

# Adjust the default behavior of the FIND_XXX() commands:
# search programs in the host environment only.
set(CMAKE_FIND_ROOT_PATH_MODE_PROGRAM NEVER)

# Search headers and libraries in the target environment only.
set(CMAKE_FIND_ROOT_PATH_MODE_LIBRARY ONLY)
set(CMAKE_FIND_ROOT_PATH_MODE_INCLUDE ONLY)
