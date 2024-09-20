# Projeto: Auto Inventory Management
Descrição
O Auto Inventory Management é um sistema desenvolvido em .NET que gerencia concessionárias, veículos, clientes e vendas. O objetivo é fornecer um controle detalhado de estoque e vendas para concessionárias de automóveis. 

Tecnologias Utilizadas: 
- Backend: .NET 8, Entity Framework, Identity, Lazy loading, Cache 
- Frontend: Bootstrap 5 e javascript Ajax
- Banco de dados: Sql Serve
  

Entidades e Relacionamentos

```
    Fabricantes (1,N) 
          |                                               
          |
        (0,N)                                               
    Veículos (1,1) --------------------- (0,N) Vendas (0,N) --------------------- (1,1) Clientes
                                               (0,N)
                                                 |      
                                                 |        
                                       (1,1) Concessionárias     
    
    Usuarios (Não diretamente relacionado a outras tabelas)

```
#### Fabricantes e Veículos:
  - Um Fabricante pode fabricar vários Veículos (1).
  - Um Veículo pode ser fabricado por apenas um Fabricante, mas pode haver veículos que não tenham um fabricante registrado (0).

#### Veículos e Vendas:
  - Cada Veículo pode estar relacionado a uma única Venda (1:1), mas pode não ser vendido (0), ou seja, não obrigatoriamente todo veículo será vendido.

#### Concessionárias e Vendas:
  - Cada Concessionária realiza várias Vendas (0), mas cada Venda ocorre em uma única Concessionária (1:1).

#### Clientes e Vendas:
  - Cada Cliente pode realizar várias Vendas (0), mas cada Venda pertence a um único Cliente (1:1).

#### Usuários:
 - Os Usuários não estão diretamente relacionados com outras tabelas no contexto descrito, mas podem desempenhar funções no sistema (como administradores ou vendedores, por exemplo).


##  1. Client (Cliente)
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

##  2. Dealer (Concessionária)
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

    ```
     public class Dealersh : BaseEntity
       {
          
           public string Name { get; set; }
           public string Address { get; set; }
           public string City { get; set; }
           public string Region { get; set; }
           public string PostalCode { get; set; }
           public string Email { get; set; }
           public string Phone { get; set; }
           public int MaximumCapacityVehicles { get; set; }
     
           // Propriedade de navegação para o relacionamento 1-N
           public virtual HashSet<Sale> Sales { get; set; } = new HashSet<Sale>();
       
       }
 
   ```

##  3. Fabricator (Concessionária)
A entidade Fabricator representa um fabricante de veículos. Cada fabricante pode produzir vários veículos.

Atributos:

- Id: Identificador único do fabricante.
- Name: Nome do fabricante.
- Country: País de origem do fabricante.
- YearFoundation: Ano de fundação do fabricante.
- WebSite: URL do site oficial do fabricante.

Relacionamentos:
 - 1 Fabricante pode produzir vários Veículos (Vehicles): Um fabricante pode estar associado a diversos veículos, indicando que ele é o produtor de diferentes modelos de veículos.


```
    public class Fabricator 
   {
       public string Name { get; set; }
       public string Country { get; set; }
       public int YearFoundation { get; set; }
       public string WebSite { get; set; }
   
       // Propriedade de navegação para o relacionamento 1-N
       public virtual HashSet<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();
   }

```

##  4. Sale (Venda)
A entidade Sale representa uma venda realizada em uma concessionária. Cada venda está associada a um veículo, a um cliente e a uma concessionária.

Atributos:

 - Id: Identificador único da venda.
 - IdDealersh: Identificador da concessionária onde a venda foi realizada.
 - IdVehicle: Identificador do veículo vendido.
 - IdClient: Identificador do cliente que realizou a compra.
 - DataSale: Data e hora em que a venda foi realizada.
 - SalePrice: Preço final do veículo vendido.
 - SaleProtocol: Número de protocolo único da venda.

Relacionamentos:
 - 1 Venda está associada a 1 Veículo (Vehicle): Cada venda corresponde a um único veículo vendido.
 - 1 Venda está associada a 1 Concessionária (Dealersh): Cada venda ocorre em uma única concessionária.
 - 1 Venda está associada a 1 Cliente (Client): Cada venda é realizada por um único cliente.


```

  public class Sale : BaseEntity
  {
    
      public int IdDealersh { get; set; }
      public int IdVehicle { get; set; }
      public int IdClient { get; set; }
      public DateTime DataSale { get; set; }
      public Decimal SalePrice { get; set; }
      public string SaleProtocol { get; set; }
  
      // Propriedades de navegação para o relacionamento 1-1
      public virtual Vehicle Vehicle { get; set; } 
      public virtual Dealersh Dealersh { get; set; }
      public virtual Client Client { get; set; }
  }
```

##  5. User (Usuário)
A entidade User representa um usuário do sistema, que pode ter diferentes níveis de acesso, como Administrador, Vendedor ou Gerente.

Atributos:

 - Id: Identificador único do usuário.
 - Name: Nome de usuário.
 - Password: Senha criptografada.
 - Email: Endereço de email do usuário.
 - UserRole: Nível de acesso do usuário, que pode ser um dos seguintes valores:
    - Administrador: Acesso completo ao sistema.
    - Vendedor: Acesso restrito, focado em operações de vendas.
    - Gerente: Acesso gerencial, incluindo a visualização de relatórios e gerenciamento de usuários.


```
 public class User : BaseEntity
 {
     public string Name { get; set; }
     public string Password { get; set; }
     public string Email { get; set; }
     public EUserRoles UserRole { get; set; }
 }
```

##  5. 6. Vehicle (Veículo)
A entidade Vehicle representa um veículo, com informações como o modelo, ano de fabricação, preço e o fabricante.

Atributos:

 - Id: Identificador único do veículo.
 - VehicleModel: Nome do modelo do veículo.
 - YearManufacture: Ano de fabricação do veículo.
 - Price: Preço do veículo.
 - IdFabricator: Identificador do fabricante (chave estrangeira).
 - VehicleType: Tipo do veículo (carro, moto, caminhão, etc.), definido pela enumeração EVehicleType.
 - Description: Descrição opcional do veículo.


Relacionamentos:
 - 1 Veículo está associado a 1 Fabricante (Fabricator): Cada veículo é fabricado por um único fabricante.
 - 1 Veículo pode estar relacionado a várias Vendas (Sales): Um veículo pode estar associado a várias vendas ao longo de sua vida útil.

```
  public class Vehicle : BaseEntity
 {
     public string VehicleModel { get; set; }
     public int YearManufacture { get; set; }
     public decimal Price { get; set; }
     public int IdFabricator { get; set; }
     public EVehicleType VehicleType { get; set; }
     public string? Description { get; set; }
 
     // Propriedades de navegação para os relacionamentos 1-1 e 1-N
     public virtual Fabricator Fabricator { get; set; }
     public virtual HashSet<Sale> Sales { get; set; } = new HashSet<Sale>();
 }
```

