# 📷 PhotoSharingApplication

Application web de partage de photos développée avec **ASP.NET Core MVC** et **Entity Framework Core** .



---

## 🚀 Technologies utilisées

| Technologie | Version |
|---|---|
| ASP.NET Core MVC | .NET 9 |
| Entity Framework Core | 9.0.0 |
| SQL Server / LocalDB | — |
| Bootstrap | 5.x |
| C# | 13 |

---

## 📁 Structure du projet

```
PhotoSharingApplication/
│
├── Controllers/
│   ├── HomeController.cs          # Contrôleur principal
│   └── PhotoController.cs         # CRUD photos
│
├── Data/
│   ├── PhotoSharingContext.cs     # Contexte Entity Framework
│   └── PhotoSharingInitializer.cs # Données initiales (Seed)
│
├── Models/
│   ├── Photo.cs                   # Modèle Photo
│   └── Commentaire.cs             # Modèle Commentaire
│
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── TestPage.cshtml
│   ├── Photo/
│   │   ├── Index.cshtml           # Galerie de photos
│   │   ├── Afficher.cshtml        # Détail d'une photo
│   │   ├── Creer.cshtml           # Formulaire de création
│   │   └── Delete.cshtml          # Confirmation suppression
│   └── Shared/
│       └── _Layout.cshtml         # Template principal
│
├── wwwroot/
│   └── Images/
│       └── flower.jpg             # Image de test
│
├── appsettings.json               # Configuration & connection string
├── Program.cs                     # Point d'entrée
└── README.md
```

---

## ⚙️ Prérequis

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server Express](https://www.microsoft.com/fr-fr/sql-server/sql-server-downloads) ou LocalDB
- [EF Core Tools](https://docs.microsoft.com/ef/core/cli/dotnet)

---

## 🛠️ Installation et configuration

### 1. Cloner le projet

```bash
git clone https://github.com/votre-username/PhotoSharingApp-AspNetCore-MVC.git
cd PhotoSharingApp-AspNetCore-MVC
```

### 2. Restaurer les packages NuGet

```bash
dotnet restore
```

### 3. Configurer la connection string

Dans `appsettings.json`, modifier la connexion selon votre configuration :

```json
{
  "ConnectionStrings": {
    "PhotoSharingDB": "Server=.\\SQLEXPRESS;Database=PhotoSharingDB;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

> Pour **LocalDB**, utiliser :
> ```
> Server=(localdb)\\mssqllocaldb;Database=PhotoSharingDB;Trusted_Connection=True;TrustServerCertificate=True
> ```

### 4. Créer la base de données

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Lancer l'application

```bash
dotnet run
```

Ouvrir le navigateur sur : `http://localhost:5250`

---


## 🎯 Fonctionnalités

### Contrôleur Photo — Actions disponibles

| Action | Méthode HTTP | URL | Description |
|---|---|---|---|
| `Index` | GET | `/Photo` | Liste toutes les photos (galerie) |
| `Afficher` | GET | `/Photo/Afficher/{id}` | Détail d'une photo |
| `Creer` | GET | `/Photo/Creer` | Formulaire de création |
| `Creer` | POST | `/Photo/Creer` | Enregistre la photo en BD |
| `Delete` | GET | `/Photo/Delete/{id}` | Demande de confirmation |
| `Delete` | POST | `/Photo/Delete/{id}` | Supprime la photo |
| `GetImage` | GET | `/Photo/GetImage/{id}` | Retourne l'image en JPEG |

---

## 🗄️ Commandes Entity Framework

```bash
# Créer une migration
dotnet ef migrations add NomMigration

# Appliquer les migrations à la BD
dotnet ef database update

# Revenir à zéro
dotnet ef database update 0

# Supprimer la dernière migration
dotnet ef migrations remove

# Lister les migrations
dotnet ef migrations list
```

---

## 🏗️ Architecture MVC

```
Requête HTTP
     ↓
 Controller        ← reçoit et traite la requête
     ↓
 Model / Data      ← accède à la BD via EF Core
     ↓
 Controller        ← prépare les données
     ↓
 View (.cshtml)    ← génère le HTML
     ↓
Réponse HTTP
```

---


> ⚠️ La version EF Core doit correspondre à la version .NET du projet.
> `.NET 9` → `EF Core 9.x.x`

---


## 👨‍💻 Auteur

Projet réalisé dans le cadre du module **Développement .Net — ASP.NET MVC**

**Realisee par  :**  Siham Bouzagrar

---


