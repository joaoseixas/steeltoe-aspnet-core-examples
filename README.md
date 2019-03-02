# steeltoe-aspnet-core-examples
This repository is complementary to the article published in: [Link InfoQ]

#pendências
-Git Ignore para os bins JAVA
-Instrução de execução do Zuul


# Executando Zuul a partir dos fontes
1. Acesse a pasta exemplo-zuul
2. Configure as regras de rota no arquivo application.yml
3. Execute o seguinte comandos
   * No Linux
    ```bash
    $ ./gradlew bootRun
    ```
   * No Windows
4. Acessar no endereço:

# Executando Eureka a partir dos fontes
1. Acesse a pasta exemplo-eureka
2. Execute o seguinte comandos
   * No Linux
    ```bash
    $ ./gradlew bootRun
    ```
   * No Windows
4. Acessar no endereço: http://localhost:9091
   
# Executando Hystrix a partir dos fontes
1. Acesse a pasta hystrix-dashboard
2. Execute o seguinte comandos
   * No Linux
    ```bash
    $ ./gradlew appRun
    ```
   * No Windows 
3. Acessar no endereço: http://localhost:7979/hystrix-dashboard/

# Executando Spring Boot Admin a partir dos fontes
1. Acesse a pasta exemplo-spring-admin
2. Execute o seguinte comandos
   * No Linux
    ```bash
    $ ./gradlew appRun
    ```
   * No Windows
3. Acessar no endereço: http://localhost:8093

# Executando API A de Exemplo a partir dos fontes
1. Acesse a pasta exemplo-api/exemplo-api-a
2. Execute o seguinte comandos
   ```bash
   $ dotnet run
   ```
3. Acessar no endereço: http://localhost:5001/swagger
4. APIs
   * POST /api/Example
     * Nela poderá realizar uma requisição, que irá chamar a API-B com o mesmo request simulando sucesso, timeout ou exception

# Executando API B de Exemplo a partir dos fontes
1. Acesse a pasta exemplo-api/exemplo-api-b
2. Execute o seguinte comandos
   ```bash
   $ dotnet run
   ```
3. Acessar no endereço: http://localhost:5002/swagger
4. APIs
   * POST /api/Status/{status}
     * Nela poderá forçar o "status" da api-b para os seguintes valores:
       * UNKNOWN
       * UP
       * WARNING
       * OUT_OF_SERVICE
       * DOWN
   * POST /api/Example
     * Nela poderá realizar uma requisição simulando sucesso, timeout ou exception
  

