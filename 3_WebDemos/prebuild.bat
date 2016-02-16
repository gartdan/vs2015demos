echo "Copying the passwords"
copy "c:\secureconfig\passwords.conf.txt" .\src\WebDemos\Config\passwords.conf

echo "Copying the connection strings"
copy "c:\secureconfig\connections.conf.txt" .\src\WebDemos\Config\connections.conf

echo %DATE% -- %TIME% >> .\src\WebDemos\Config\lastbuild.txt