# BookLog
App para registrar livros que leu e gostaria de ler

## Rodando localmente

O banco é um PostgreSQL hospedado no [Supabase](https://supabase.com).

### 1. Connection string

A connection string **não fica no repositório**. Ela é guardada com o user-secrets do .NET, fora da pasta do projeto.

No Supabase, clique em **Connect** → **Session pooler** → tipo **.NET**, e monte a string neste formato:

```
Host=<HOST>;Port=5432;Database=postgres;Username=postgres.<ID_DO_PROJETO>;Password=<SENHA_DO_BANCO>;SSL Mode=Require
```

Depois salve no user-secrets:

```bash
cd backend/BookLogApi
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "<connection string>"
```

> No PowerShell, se a senha tiver `$`, use aspas simples na connection string.
> No Visual Studio também dá para editar pelo clique direito no projeto BookLogApi → **Manage User Secrets**.

### 1.1 Chave do JWT

A chave que assina os tokens de login também fica no user-secrets. Gere uma chave aleatória (no mínimo 32 caracteres) e salve:

```powershell
cd backend/BookLogApi
dotnet user-secrets set "Jwt:Key" ([Convert]::ToBase64String([Security.Cryptography.RandomNumberGenerator]::GetBytes(64)))
```

### 1.2 Supabase Storage (imagens)

As fotos de perfil e capas ficam no bucket público `images` do Supabase Storage. A URL do projeto fica em **Project Settings → Data API** e a chave secreta em **Project Settings → API Keys** (`sb_secret_...` ou a legada `service_role`):

```powershell
cd backend/BookLogApi
dotnet user-secrets set "Supabase:Url" 'https://<ID_DO_PROJETO>.supabase.co'
dotnet user-secrets set "Supabase:SecretKey" '<CHAVE_SECRETA>'
```

### 2. Migrations

Para criar ou atualizar as tabelas no banco:

```bash
cd backend
dotnet ef database update --project Infrastructure --startup-project BookLogApi
```

> Sem o `dotnet-ef` instalado, dá para rodar com o .NET 10 SDK usando
> `dotnet dnx dotnet-ef@10.0.15 --yes --source https://api.nuget.org/v3/index.json database update --project Infrastructure --startup-project BookLogApi`

### 3. API

```bash
cd backend
dotnet run --project BookLogApi --launch-profile https
```

Swagger: `https://localhost:7062/swagger`
