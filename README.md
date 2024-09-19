# Projeto: Auto Inventory Management
Descrição
O Auto Inventory Management é um sistema desenvolvido em .NET que gerencia concessionárias, veículos, clientes e vendas. O objetivo é fornecer um controle detalhado de estoque e vendas para concessionárias de automóveis.

Entidades e Relacionamentos
# 1. Client (Cliente)
A entidade Client representa um cliente no sistema. Cada cliente pode realizar várias compras de veículos. Aqui estão os principais atributos e relacionamentos:

Atributos:

- Id: Identificador único do cliente.
- Name: Nome do cliente.
- Email: Email do cliente.
- Phone: Telefone do cliente.

Relacionamentos:
 - 1 Cliente pode realizar várias Vendas (Sales): Um cliente pode estar associado a diversas vendas.

```
    public class Client
  {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }
      
      // Propriedade de navegação para o relacionamento 1-N
      public virtual ICollection<Sale> Sales { get; set; }
  }
```

#2. Dealer (Concessionária)
A entidade Dealer representa uma concessionária. Cada concessionária pode vender vários veículos e realizar múltiplas vendas.

Atributos:

- Id: Identificador único da concessionária.
- Name: Nome da concessionária.
- Address:  Endereço completo da concessionária.
- City:  Estado onde a concessionária está localizada.
- Region: Estado onde a concessionária está localizada.
- PostalCode:  CEP da concessionária.
- Email:  Email de contato.
- Phone:  Telefone de contato.
- MaximumCapacityVehicles:  Capacidade máxima de veículos que a concessionária pode armazenar.

Relacionamentos:
 - 1 Concessionária pode realizar várias Vendas (Sales): Uma Concessionária pode estar associado a diversas vendas.


