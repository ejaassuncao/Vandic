# Vandic

## Sistema de gerenciamento de vendas
### Entidades:
- Usuario (Email, SENHA), perfil, Rules etc...
- Contato cttID
	 - ContatoID
	 - Telefone
	  - Celular
	 - EmailAlternativo
	
- Estado (puxar de alguma API)
- Cidade  (puxar de alguma API)
- Endereco
	- Logradouro (rua, avenida, travessa etc.)
	- CEP
	- Referencia
	- Numero
	- Bairro
	- Complemento
	- CidadeID
	- Estado iD

- Pessoa (ID)
    - PesID
    - Tipo (PF, PJ)
    - NomeRazao
    - NomeFantasiaApelido
    - Foto
    - Documento
    - Contato
    - Endereco
    - UsuID
	  
- PessoaEndereco (Pessoa pode possuir varios endereços)

- Estoque * Conta Corrente entrada SaidaEstado
    -id  
    - ProdutoId
    - QtdTotal
    - PrecoMédio  
    - DataEntrada

- LancamentosEstoque **
  -ID
  - EstoqueId
  - Status (Entrada/Saida)
  - MotivoID  (Entrada-Compra;Entrada-Bonificação; Saida-Vendas; Saida-Quebra)
  - DescricaoMotivoOutro
  - Produto 
  - Data
  - Qtd
  - Valor
  - Nº Nota fiscal
 
- Produto (PRD)
    - PrdID
    - Fornecedor
    - Nome   
    - CodBarra
    - Imagem
    - Descrição
    - PreçoCompra   
    - Margem
    - PreçoVenda
    - CtgId (categoria)

- Category (Ctg)
    - CtgId
    - CtgName
    - CtgDescription
    - CtgMenuDescription
    - CtRoot

- Pedido  (PPD)
    - PddID
    - PesID (Cliente)
    - DataHora
    - Endereco de Entrega
    - Status (Carrinho, Processamendo Pagamento, Pagamento Realizado, EmissaoNota, Enviado, Finalizado)
    - PromocaoId
    - IP - Pra recuperar um carrinho perdido

- ItensPedido (IPD)
    - IpdID
    - PPDID (produtoID)
    - Quantidade
    - PrecoUnitario
    - Total
- Promoções
	- Descrição
	- DataInicio
 	- DataFim
        - Desconto%
   
- Venda
- Pedidoid
- CodigoRastreio
- Entregador
- Nº Nota



- Loja



   
###  casos de uso
- Permitir Gerenciar um usuário
- Permitir Gerenciar Perfis e Regras
- Permitir Gerenciar  (Pesquisar, Listar, Inserir, Editar, Excluir) Pessoa
- Permitir Gerenciar  produtos
- Permitir Integrar com sistema de pagamento via API.
- Permitir Gerenciar Promoções e Descontos
- Permitir Gerenciar um carrinho de compras
- Permitir Gerenciar as Vendas
- Após realizar pedido venda eh enviada um email de confirmação;
- Tela de gerecimento de pedidos modificação de status.

### Usar o mudblazor para criação das tela
 Site: https://mudblazor.com/

## Executar o scaffold para regerar os mapeamentos atualizados e atualizar o modelo das classes;

sqlServer:
```powershell
Scaffold-DbContext "Name=ConnectionStrings:DefaultConnection" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Temp" -ContextDir "Temp" -Context  "AppDbContextTemp"  -Project "Vandic.Data.EfCore" -StartupProject "Vandic.Api"  -Force
```


## Criação das Migration 
Gerando a migrations inicial para o banco de dados
```powershell
Add-Migration initial -Context AppDbContext  -StartupProject Vandic.Api

```

Abra o arquivo gerado (ex: 20250502180000_initial.cs) e limpe os métodos Up() e Down(), assim:
executando a migration no banco de dados

```Csharp  
protected override void Up(MigrationBuilder migrationBuilder)
{
    // vazio
}

protected override void Down(MigrationBuilder migrationBuilder)
{
    // vazio
}
```


```powershell
Update-Database  -Context AppDbContext -StartupProject Vandic.Api

```
para criação do script
```powershell
Script-Migration -Context AppDbContext -StartupProject Vandic.Api
```


## Padrões de projeto
-  DDD (Domain Driven Design)
 - CQRS (Command Query Responsibility Segregation)
 - WebApi
 - BlazorServer And BlazorWebAssembly
 - CrossCutting Concerns (Autenticação, Autorização, Log, Cache, Exception Handling, Validação de Dados, etc.)
 - Serviços de Aplicação (Application Services)
 - Event Sourcing Notifications