# API Cursos

API REST desenvolvida em ASP.NET Core para gerenciamento de cursos.

O projeto permite realizar cadastro, consulta, atualização e exclusão lógica de cursos, utilizando boas práticas de desenvolvimento backend com separação em camadas, DTOs, Services e documentação Swagger.

---

# Funcionalidades

- Cadastro de cursos
- Listagem de cursos ativos
- Busca de curso por ID
- Atualização de cursos
- Exclusão lógica de cursos
- Listagem de períodos disponíveis

---

# Tecnologias Utilizadas

| Tecnologia | Versão |
|---|---|
| .NET | 10.0 |
| ASP.NET Core Web API | 10.0 |
| Entity Framework Core Design | 9.0.0 |
| Entity Framework Core Tools | 9.0.0 |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 |
| MySQL / MariaDB | 10+ |
| Swashbuckle.AspNetCore | 6.5.0 |
| Scalar.AspNetCore | 2.14.11 |

---

# Estrutura do Projeto

```txt
API_Cursos/
│
├── Common/
├── Controllers/
├── DTOs/
├── Enums/
├── Models/
├── Services/
├── Migrations/
├── Properties/
│
├── Program.cs
├── appsettings.json
└── README.md
```

---

# Configuração do Banco de Dados

## 1. Criar banco de dados no MySQL

```sql
CREATE DATABASE db_cursos;
```

---

## 2. Configurar conexão

No arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=db_cursos;user=root;password=SUA_SENHA"
  }
}
```

---

# Como Executar o Projeto

## 1. Clonar o repositório

```bash
git clone https://github.com/devGabrielDuarte07/API-Curso.git
```

---

## 2. Entrar na pasta do projeto

```bash
cd API-Curso
```

---

## 3. Restaurar dependências

```bash
dotnet restore
```

---

## 4. Criar Migration

```bash
dotnet ef migrations add InitialCreate
```

---

## 5. Executar Migration no banco

```bash
dotnet ef database update
```

---

## 6. Executar aplicação

```bash
dotnet run
```

---

# Swagger

Após iniciar a aplicação, acessar:

```txt
https://localhost:xxxx/swagger
```

---

# Endpoints

| Método | Endpoint | Descrição |
|---|---|---|
| GET | `/api/cursos` | Lista cursos ativos |
| GET | `/api/cursos/{id}` | Busca curso pelo ID |
| POST | `/api/cursos` | Cria um curso |
| PUT | `/api/cursos/{id}` | Atualiza um curso |
| DELETE | `/api/cursos/{id}` | Realiza exclusão lógica |
| GET | `/api/cursos/periodos` | Lista períodos disponíveis |

---

# Exemplo de Requisição

## POST `/api/cursos`

```json
{
  "nome": "DESENVOLVIMENTO DE SISTEMAS",
  "periodo": "NOTURNO"
}
```

---

# Períodos Disponíveis

- MATUTINO
- VESPERTINO
- NOTURNO
- INTEGRAL

---

# Padrões Utilizados

- DTO Pattern
- Service Layer
- Soft Delete
- Response Pattern (`ResultadoPadrao`)
- Entity Framework Core
- Swagger Documentation

---

# Autor

Gabriel Duarte

GitHub:
https://github.com/devGabrielDuarte07
