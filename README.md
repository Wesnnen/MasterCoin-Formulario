# MasterCoin - Formulario
Este é um sistema simples de cadastro de usuários, onde os usuários podem se registrar fornecendo informações como nome, data de nascimento, e-mail e senha. O sistema valida os dados fornecidos e garante que o e-mail seja do domínio `@mastercoin.com.br`   e que a senha tenha ao menos 8 caracteres, incluindo letras, números e caracteres especiais.

## Funcionalidades:
* Cadastro de usuários com um ID único para cada um.
* Validação da data de nascimento para garantir que não seja maior que a data atual.
* Validação do e-mail para garantir que seja do domínio `@mastercoin.com.br`.
* Validação da senha para garantir que tenha pelo menos 8 caracteres e inclua letras, números e caracteres especiais.
* Exibição dos usuários cadastrados com ID, Nome e Idade.

## Como funciona:
1. O programa solicita que o usuário digite o nome, a data de nascimento, o e-mail e a senha.
2. Para a data de nascimento, o programa valida se a data não é maior que a data atual.
3. O e-mail deve ser do domínio `@mastercoin.com.br` e não pode ser repetido.
4. A senha deve ter pelo menos 8 caracteres, incluindo letras, números e caracteres especiais.
5. Após o cadastro de cada usuário, o programa pergunta se o usuário deseja cadastrar outro. Se a resposta for "Sim", o processo continua.
6. No final, o programa exibe todos os usuários cadastrados com suas respectivas idades.

## Explicação dos principais componentes:
### 1. Classe `Usuario`:
  * Propriedades:
      * `ID`: O identificador único para cada usuário.
      * `Nome`: O nome do usuário.
      * `DataNascimento`: A data de nascimento do usuário.
      * `E-mail`: O e-mail do usuário, com validação de domínio.
      * `Senha`: A senha do usuário, com validação de segurança.
  * Propriedade `Idade`: Calcula a idade do usuário com base na data de nascimento e na data atual.

### 2. Funções de Validação:

  * Data de nascimento: Garantir que a data não seja maior que a data atual.
  * E-mail: Verificar se o domínio é `@mastercoin.com.br` e se o e-mail já não foi cadastrado.
  * Senha: Validar se a senha tem pelo menos 8 caracteres e inclui letras, números e caracteres especiais.

## Fluxo do programa:

  * O programa permite o cadastro de múltiplos usuários e valida os dados conforme são fornecidos.
  * Após o cadastro, o programa exibe os usuários cadastrados e suas idades.

## Como rodar:
  1. Clone ou faça o download do repositório.
  2. Abra o arquivo no Visual Studio ou em qualquer outro editor C#.
  3. Compile e execute o programa.
  4. Siga as instruções no console para cadastrar os usuários.
