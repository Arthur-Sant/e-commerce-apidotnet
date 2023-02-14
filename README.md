# 🏪 E-commerce dotnet

### Descrição:

#### Api simples usando a linguagem C# simulando um CRUD de um produto. Para conexão com o banco de dados uso o orm dapper, no entanto para o conexão ocorrer, é preciso mudar as configurações no arquivo appsettings.json .

#### Na rota de exclusão do produto, eu apenas seto um dos campos com "isDelted: true", para quer o produto ainda permaneça no banco de dados. Na hora de buscar todos os produto, existe um filtro que bsuca produtos que o campo "isDeleted" seja falso.
