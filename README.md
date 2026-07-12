# Sistema de Pedidos — Restaurante

Sistema para gerenciamento de pedidos de restaurante, desenvolvido em ASP.NET Core MVC (C#).

## Funcionalidades

- Cadastro de pedidos (produto, quantidade, mesa, solicitante)
- Telas separadas para Cozinha (pratos) e Copa (bebidas)
- Atualização de status (Preparando → Pronto → Entregue)
- Login de usuários
- Histórico de pedidos finalizados

## Tecnologias

- ASP.NET Core MVC + Bootstrap
- SQL Server LocalDB + Entity Framework Core (apenas para usuários/login)
- Pedidos e Produtos ficam em memória, sem persistência em banco

## Como executar

1. Clone o repositório e abra `Restaurante.slnx` no Visual Studio
2. Deixe os pacotes NuGet restaurarem automaticamente
3. No **Console do Gerenciador de Pacotes**, rode:
   ```
   Update-Database
   ```
4. O comando acima já cria automaticamente um usuário de teste:
   - **E-mail:** admin@teste.com
   - **Senha:** 123456
5. Rode o projeto (`Ctrl+F5`) e faça login com o usuário acima

## Observações

- Senha é armazenada sem hash
