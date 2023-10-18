# Products Api

## Instruções para rodar a Api

- Primeiro, acesse o appSettings.json na pasta Api e mude a connectionString do SqlServer para a sua.

### Execute os seguintes comandos

. dotnet restore
.dotnet tool install --global dotnet-ef --version 7.0.11
. cd Infra/
. dotnet ef database update --startup-project ../Api

- Feito isso, você criará o banco de dados e as tabelas necessárias.

- Agora é só acessar a pasta api e rodar o projeto.