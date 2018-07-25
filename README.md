C# LOG
==============


Esta aplicação visa criar um mecanismo de LOG simples para ser utilizado em qualquer aplicação.
O objetivo é simplificar e dar opções para o desenvolvedor escolher onde suas saídas serão armazenadas.


Instruções
--------
Para utilizar essa biblioteca basta criar uma DLL a partir do código aqui disponível e importa-la em seu projeto.
Após a instalação dessa biblioteca você pode configurar o arquivo de configuração para parametrizar onde ocorrerá a saída do dos LOGS e o formato das mensagens. 

As configurações disponíveis são:
```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <target name="HTTP" minlevel="DEBUG" url="http://ptsv2.com/t/8erlh-1532184489/post" />
  <target name="CONSOLE" minlevel="INFO"/>
  <target name="FILE" minlevel="INFO" path="C:\Users\ra00099907\Desktop\ClassLog\log.txt"/>

  <messageFormat pattern="Mensagem: [MESSAGE] - Timestamp: [TIMESTAMP] - Level: [LEVEL]"/>

</configuration>
```
O nó `target` refere-se ao tipo de saída do LOG e somente target deve ser escolhido por vez.
Abaixo vemos as configurações adicionais para cada tipo escolhido.

Quando selecionado a opção HTTP devemos passar uma URL para onde será feito o POST com a mensagem a ser logada no parâmetro `url` do XML
Quando selecionado o target FILE devemos passar o `path` onde será armazenado o arquivo contendo as mensagens logadas.

Todos os targets possuem o parâmetro `minlevel` onde temos as opções:

        TRACE 
        DEBUG 
        INFO
        WARN
        ERROR
        FATAL

O nó `messageFormat` é onde podemos fomatar a mensagem do LOG.
Nesse nó temos a opção `pattern` onde temos três palavras-chave:

        MESSAGE 
        TIMESTAMP 
        LEVEL

O parâmetro MESSAGE refere-se a mensagem que será logada.
O parâmetro TIMESTAMP refere-se a data que o log foi gerado.
O parâmetro LEVEL refere-se ao nível de log escolhido.

Usando a biblioteca
--------

Após as configurações acima o uso da biblioteca fica extremamente simples uma vez que precisamos somente instanciar a classe Logger e invocar a função Log passando em que nível desejamos logar e a mensagem.

Abaixo segue como a biblioteca deve ser utilizada, mostrando o qual fácil é seu uso:

```csharp
Logger logger = new Logger();
logger.Log(Level.INFO, "Meu primeiro LOG");
```
