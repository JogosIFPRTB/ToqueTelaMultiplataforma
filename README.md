# 🎮 Unity Touch Scripts
Este repositório contém três scripts em C# para Unity, desenvolvidos para ensinar e demonstrar o uso de entrada por toque em dispositivos móveis e cliques no editor.  

---

## 📜 **Descrição dos Scripts**
### 📍 `MultiploToque.cs`
🔹 **Objetivo:** Instancia um objeto na posição do toque ou clique.  
🔹 **Funcionamento:**
- Quando o usuário toca na tela ou clica com o mouse, um objeto é instanciado.
- Se houver múltiplos toques, cada um gera uma nova instância.
- O objeto é destruído automaticamente após **1 segundo**.

🔹 **Personalização:**
- O tempo de destruição pode ser alterado na linha:  
```csharp
  Destroy(clone, 1f); // Altere 1f para o tempo desejado
```

---

### 📍 `TouchScript.cs`
🔹 **Objetivo:** Move o objeto diretamente para a posição do toque ou clique.
🔹 **Funcionamento:**
- O objeto teletransporta para a posição do toque.
- Suporta múltiplos dispositivos, incluindo Android e testes no Editor (mouse).
  
🔹 Personalização:
- Para evitar movimentos bruscos, utilize interpolação:
Substitua esta linha:
```csharp
transform.position = posicaoMundo;
```
Por:
```csharp
transform.position = Vector3.Lerp(transform.position, posicaoMundo, 0.1f);
```
Assim, o objeto se moverá suavemente para o destino.

---

### 📍 `MoveToTouch.cs`
🔹 **Objetivo:** Move o objeto suavemente na direção do toque.
🔹 **Funcionamento:**
- Em vez de teletransportar, o objeto se move gradualmente para a posição do toque.
- Se houver múltiplos toques, ele se move para um ponto intermediário entre eles.
- Usa Vector3.MoveTowards() para um deslocamento controlado.
  
🔹 Personalização:
- Para um movimento mais suave, troque:
```csharp
transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
```
Por:
```csharp
transform.position = Vector3.Lerp(transform.position, destino, 0.1f);
```
Isso tornará o movimento mais fluido.

---

## 🚀 Instalação e Execução

### **1️⃣ Clonar o repositório**
```bash
git clone https://github.com/JogosIFPRTB/ToqueTelaMultiplataforma.git
```

---

### **2️⃣ Abrir no Unity**
Abra o Unity Hub.
Clique em Open e selecione a pasta do projeto.
Aguarde a importação dos arquivos.

---

### **3️⃣ Executar o Jogo**
- No Unity, vá até File → Build & Run ou pressione Play no Editor.
- Teste o cliques ou toques na tela.

---

## 📄 **Licença**
- Este projeto é open-source.
- Sinta-se à vontade para usar, modificar e compartilhar!

---

## 👨‍🏫 **Sobre**
📌 Desenvolvido para fins educacionais.
📌 Criado para ensinar entrada por toque e movimentação na Unity.
📌 Feedbacks e melhorias são sempre bem-vindos! 🚀


