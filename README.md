# Desafio 1: Restaurante Sabor do Brasil

Olá meu nome e <b>Paola Jacquin</b>, sou dona do renomado restaurante <b>Sabor do Brasil</b>.
Eu contratei a sua empresa para que vocês desenvolvam um sistema para a gestão do meu restaurante.

O sistema deve ter as seguintes funcionalidades:

## Gestão da Mesas

Nosso espaço é reservado para até 120 pessoas, cabendo 20 mesas.

O Sistema deve controlar a abertura e fechamento dessas mesas.

Nossas mesas são luxuosas e cabem até 6 pessoas cada. Podemos juntar apenas duas mesas, nada além disso.

Não podemos ter pessoas de pé dentro do restaurante, sendo assim precisamos calcular quantas mesas estão disponíveis.

- Apenas os usuários do tipo Garçom podem efetuar pedidos.


## Gestão dos Pratos

Nosso cardápio é variado e digital, e cada dia temos 4 opções diferentes. O sistema deve permitir o cadastro dessas opções e seus preços por dia.

Nossos ingredientes são de altíssima qualidade, sendo assim precisamos controlar o estoque de forma rígida. 

Cada prato é formado por vários ingredientes cadastrados. O sistema deve travar o preparo de um prato caso falte algum ingrediente.

É importante que o sistema atualize o cardápio digital caso não seja possível preparar algum prato.

- Apenas os usuários do tipo Cozinheiro podem cadastrar pratos e receitas.


## Gestão de Estoque

Como citei acima, precisamos ter uma gestão de estoque robusta. E para isso, a cada prato vendido, precisamos dar baixa nos ingredientes em estoque.

Cada item do estoque tem uma quantidade máxima e quantidade mínima, isto é, não podemos ter mais ingrediente do que a quantidade máxima cadastrada (perigo de estragar ou ultrapassar o prazo de validade), e quando o ingrediente chegar na quantidade mínima ou menor que isto, um e-mail de alerta deve ser enviado à gerente: devbrofficial@gmail.com. O sistema deve alertar a gerente a cada 6 horas.

É necessário ter um relatório onde seja possível extrair quais ingredientes estão com a quantidade menor ou igual a quantidade mínima cadastrada.

Esse relatório será útil para a gerente efetuar a compra e dar entrada no estoque via sistema. 

Caso seja dada entrada no estoque de uma quantidade de ingrediente que a soma total ultrapasse a quantidade máxima cadastrada, o sistema deve gravar um log informando um possível desperdício. Esse log deve estar disponível para consulta a qualquer momento.

- Apenas os usuários do tipo Estoquista e Cozinheiro podem cadastrar ingredientes.

- Apenas os usuários do tipo Estoquista podem cadastrar quantidade em estoque.

- Apenas os usuários do tipo Gerente têm acesso aos relatórios

## Gestão do Caixa

Esta é uma das funcionalidades mais importantes então certifique-se de que o sistema vai calcular de forma correta os valores.

Nós podemos ter de 1 a 3 caixas abertos dependendo da quantidade de pessoas no restaurante. 

Caso tenhamos até 20 pessoas, abrimos apenas um caixa, de 21 a 50 pessoas, abrimos o segundo caixa, acima de 51 pessoas, abrimos o terceiro caixa.

O Operado de Caixa pode decidir fechar o caixa caso a quantidade de pessoas diminua no restaurante.

Não é possível abrir um caixa duas vezes no dia com o mesmo login.

Lembrando que não podemos ter o mesmo usuário logado em mais de um caixa.

Antes de fechar o caixa, é necessário imprimir a valor total arrecadado para o operador de caixa logado e a Gerente deve conferir os valores e entrar com a sua senha confirmando o fechamento. Caso os valores não batam, deve-se gerar um log com as informações de diferença.

Não é possível efetuar recebimentos caso a data de fechamento seja diferente da data de abertura.

O Sistema deve ter um relatório por período mostrando o faturamento do dia por caixa, operador e forma de pagamento.

Deve-se ter um relatório para listar os caixas que tiveram problemas de divergência no fechamento.

Esse relatório deve conter a data, os valores de diferença, o nome do gerente e o nome do operador de caixa.

- Apenas os usuários do tipo Operador de Caixa e Gerente podem efetuar o recebimento da conta, abertura e fechamento do caixa.
- Apenas os usuários do tipo Gerente podem visualizar os relatórios


## Fechamento da Conta

Nós aceitamos pagamento em dinheiro, cartão de crédito, cartão de débito e PIX.

Para facilitar a vida de nossos clientes, o sistema já informa a conta dividida entre as pessoas da mesa.

O pagamento de uma conta pode ser feito por vários meios de pagamento.

Caso o cliente tenha gostado do serviço, poderemos adicionar a taxa de 10% na conta.

Uma vez que a conta seja fechada, o sistema não deve permitir a inclusão/exclusão de novos itens.

- Apenas os usuários do tipo Operador de Caixa, Gerente e Garçom podem efetuar o fechamento da conta.


## Gestão de Promoções

O sistema deverá permitir o cadastro de promoções. 

A promoção pode variar por um horário (Happy Hour), por um dia específico da semana (Quarta-Feira do Futebol) ou uma data comemorativa (Dia das mães).

E promoção pode ser aplicada em um prato ou em um combo (Combo: Entrada + Prato Principal + Sobremesa). 

- Apenas os usuários do tipo Gerente podem criar promoções


-------
-------


## Informações técnicas

- O projeto deve ser um Web API com C#
- O projeto deve disponibilizar as APIs via Swagger
- A escolha da arquitetura é livre
- A escolha do banco de dados é livre

## O que será avaliado

- Modelagem de Dados
- Modelagem da Aplicação
- Aderência aos Requisitos de Negócio
- Trabalho em Equipe 
- Gestão de Tarefas (Usar o Projetcs do Github)
- Cerimônias do Scrum
- Evolução técnica do time

## Materiais/Conteúdos que serão disponibilizados pelos mentores

- Treinamento em Scrum
- Documentação da Microsoft (Microsoft Learning)
- Vídeos sobre temas como Orientação a Objetos, SOLID, Testes Unitários e afins
- Vídeos periódicos para esclarecimento de dúvidas 


-------
-------

Esse é um projeto feito pela comunidade e para a comunidade ❤️. 

Caso tenha alguma dúvida e/ou sugestão, crie uma Issue nesse repositório.

Caso encontre algum erro, por favor, abra uma Issue ou nos envie um Pull Request.
