# MatchFlix - Back-end API 🍿🎬

Este é o repositório do Back-end do **MatchFlix**, uma API desenvolvida para o Trabalho Prático da PUC. O objetivo do sistema é permitir que grupos de amigos criem sessões de votação para escolher de forma inteligente e automatizada (através de "Matches") qual filme assistir em conjunto.

A API foi construída seguindo a arquitetura REST utilizando uma estrutura totalmente desacoplada, o que permite que o Front-end seja desenvolvido de forma independente em outra pasta/repositório.

---

## 🚀 Tecnologias Utilizadas

* **Runtime:** .NET 9.0
* **Framework Web:** ASP.NET Core Web API
* **ORM (Mapeamento de Banco):** Entity Framework Core (EF Core)
* **Banco de Dados:** MySQL
* **Documentação de Rotas:** Swagger / OpenAPI

---

## 📂 Estrutura de Controllers (Regras de Negócio)

O sistema conta com **5 controllers principais** que gerenciam as 9 tabelas relacionais do banco de dados:

1. **`UsuariosController`:** Responsável pelo cadastro de usuários e fluxo de autenticação/login.
2. **`FilmesController`:** Gerencia a inserção, busca por ID e a listagem do catálogo de filmes.
3. **`GenerosController`:** Controla as categorias dos filmes (Ação, Comédia, Terror, etc.).
4. **`GruposController`:** Cuida da criação de grupos de sessões e do vínculo/entrada de membros nesses grupos.
5. **`SessoesController`:** O "cérebro" do app. Abre sessões de votação ativa, computa os votos individuais (`like` ou `dislike`) e calcula automaticamente os **Matches** quando todos os membros do grupo dão "Like" no mesmo filme.

---

## 🛠️ Como Executar o Projeto Localmente

### Pré-requisitos
* [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) instalado.
* Servidor [MySQL](https://dev.mysql.com/downloads/installer/) ativo.

### 1. Configurar a Conexão com o Banco
Abra o arquivo `appsettings.json` na raiz do projeto e ajuste a sua `ConnectionString` com as credenciais do seu MySQL local:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=matchflix;Uid=SEU_USUARIO;Pwd=SUA_SENHA;"
}
