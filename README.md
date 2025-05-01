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

- Stoque * Conta Corrente entrada SaidaEstado
  -id
  -Status  (Entrada - Saida)
  -ProdutoId
  -Qtd 
  -Fornedor (Pessoa) 
  -dataEntrada
   

- Produto (PRD)
    - PrdID
    - Nome
    - Imagem
    - Descrição
    - Preço
    - Localizacao
    - Margem    
    - Qtd
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
	- Status (Pedido em Processamento, Pagamento Realizado, Em Andamento,  Finalizado)
	- PromocaoID
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
