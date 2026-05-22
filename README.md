# 🔢 Conversor de Bases Numéricas

Programa de console desenvolvido em **C#** que converte números entre diferentes bases numéricas, incluindo bases customizadas de 2 até 36.

---

## 📋 Funcionalidades

- Conversão entre as bases pré-definidas: **Binária (2), Quinária (5), Octal (8), Decimal (10) e Hexadecimal (16)**
- Suporte a **bases customizadas** entre 2 e 36
- Suporte a dígitos **hexadecimais e além** (letras A-Z)
- Validação completa de entradas inválidas
- Interface de menu interativa no terminal
- Loop contínuo — converta quantas vezes quiser sem reiniciar o programa

---

## 🚀 Como executar

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) instalado na máquina

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/GabrielPerecim/Conversor-de-Bases-Numericas.git
```

2. Acesse a pasta do projeto:
```bash
cd Conversor-de-Bases-Numericas
```

3. Execute o programa:
```bash
dotnet run
```

---

## 🛠️ Como usar

1. Ao iniciar, o programa exibe um menu com as bases disponíveis
2. Escolha a **base de origem** do número que deseja converter
3. Escolha a **base de destino**
4. Digite o número a ser convertido
5. O resultado será exibido na tela
6. Pressione qualquer tecla para fazer uma nova conversão
7. Digite **-1** em qualquer menu para sair do programa

### Exemplo
```
5 (base 10) --> ?(base 2)
==========================
          101
==========================
```

---

## ✅ Validações

O programa trata os seguintes casos:
- Dígito incompatível com a base escolhida (ex: `9` em binário)
- Entrada vazia
- Letras digitadas onde se espera número no menu
- Opções fora do menu (ex: digitar `14` diretamente)
- Base customizada inválida (menor que 2)

---

## ⚠️ Limitações
- O conversor suporta números de até **9.223.372.036.854.775.807** (valor máximo de um long de 64 bits)
- Bases suportadas: de **2 até 36**

## 🏗️ Estrutura do código

| Função | Descrição |
|--------|-----------|
| `ExibirMenu()` | Exibe o menu e retorna a base escolhida |
| `ConverterParaDecimal()` | Converte qualquer base para decimal |
| `ConverterDeDecimal()` | Converte decimal para qualquer base |

A estratégia de conversão é: **base origem → decimal → base destino**

---

## 📚 Tecnologias

- C# (.NET)
- Console Application

---

## 👨‍💻 Autor

Desenvolvido por **Gabriel Perecim** — estudante de Análise e Desenvolvimento de Sistemas na FATEC Ribeirão Preto.
