# Application de Gestion des Étudiants - Notes

![Capture d'écran de l'application](image_1.png)

---

## 🎯 Aperçu

Une application Windows Forms complète pour gérer les dossiers étudiants et les notes avec le système de notation marocain (0-20). Conçue pour les institutions éducatives avec une interface unifiée et des fonctionnalités d'exportation avancées.

## ✨ Fonctionnalités Principales

- **🎨 Interface Utilisateur **
  - Gestion des étudiants et des notes côte à côte dans une seule fenêtre
  - Grilles de données pour visualiser les enregistrements avec sélection de ligne complète
  - Panneaux de formulaires organisés pour la saisie et l'édition de données
  - Fonctionnalité de recherche dans les deux modules
  - Validation des données en temps réel
  - Fonctionnalité d'exportation avec plusieurs formats

- **👥 Gestion des Étudiants** (Panneau Gauche)
  - Ajouter, modifier, supprimer des étudiants
  - Rechercher des étudiants par nom, email ou ID
  - Validation d'email unique
  - Vérification d'existence de l'ID étudiant
  - Opérations CRUD complètes avec validation
  - Exporter les étudiants en CSV et Excel

- **📊 Gestion des Notes** (Panneau Droit)
  - Ajouter, modifier, supprimer des notes avec le système marocain (0-20 points)
  - Visualiser les notes par étudiant ou matière avec indicateurs de niveau
  - Calculer les moyennes par étudiant avec conversion en pourcentage
  - Suivi de l'historique des notes
  - Sélection d'étudiant via menu déroulant
  - Recherche avancée par matière
  - Exporter les notes en CSV, Excel et PDF
  - Génération de rapports complets avec plusieurs feuilles de calcul

- **📈 Capacités d'Exportation**
  - **Export CSV** : Données des étudiants et des notes
  - **Export Excel** : Étudiants, notes et rapports complets avec statistiques
  - **Export PDF** : Rapports de notes professionnels avec analyses
  - **Rapports Multi-feuilles** : Rapports Excel combinés avec analyses de synthèse

- **🗄️ Intégration Base de Données**
  - Connectivité base de données MySQL
  - Chaînes de connexion configurables
  - Test de connexion au démarrage
  - Gestion d'erreurs et validation
  - Support des transactions
  - Analyses avancées et rapports

## 🛠️ Stack Technologique

- **.NET 8** - Framework cible
- **Windows Forms** - Framework UI avec disposition SplitContainer
- **MySQL** - Base de données
- **MySql.Data** - Connecteur de base de données
- **C# 12** - Langage de programmation

## 📋 Prérequis

- .NET 8 Runtime/SDK
- Serveur MySQL

## 🚀 Instructions d'Installation

1. **Configuration de la Base de Données**
   - Installer MySQL Server
   - Exécuter le script `database_setup.sql` pour créer la base de données et les tables
   - Mettre à jour la chaîne de connexion dans `app.config` si nécessaire

2. **Configuration**
   - Mettre à jour la chaîne de connexion dans `app.config` :
   ```xml
   <connectionStrings>
       <add name="StudentManagementDB" 
            connectionString="Server=localhost;Database=student_management;Uid=root;Pwd=votre_mot_de_passe;" 
            providerName="MySql.Data.MySqlClient" />
   </connectionStrings>
   ```

## 📁 Structure du Projet

```
student-management-app/
├── Models/
│   ├── Student.cs          # Modèle d'entité étudiant
│   └── Grade.cs            # Modèle d'entité note avec système marocain
├── DataAccess/
│   ├── DatabaseConnection.cs  # Gestionnaire de connexion base de données
│   ├── StudentDAL.cs       # Couche d'accès aux données étudiants
│   └── GradeDAL.cs         # Couche d'accès aux données notes améliorée
├── Services/
│   └── ExportService.cs    # Service de fonctionnalité d'exportation
├── Form1.cs                # Code-behind du formulaire principal
├── Form1.Designer.cs       # Code designer de l'interface unifiée
├── Form1.resx              # Ressources du formulaire
├── Program.cs              # Point d'entrée de l'application
├── app.config              # Fichier de configuration
└── database_setup.sql      # Script de configuration BD avec données marocaines
```

## 🗃️ Schéma de Base de Données

### Table Étudiants
- `student_id` (VARCHAR(20), PRIMARY KEY)
- `first_name` (VARCHAR(50), NOT NULL)
- `last_name` (VARCHAR(50), NOT NULL)
- `email` (VARCHAR(100), NOT NULL, UNIQUE)
- `phone` (VARCHAR(20))
- `created_date` (DATETIME, DEFAULT CURRENT_TIMESTAMP)

### Table Notes (Système Marocain)
- `grade_id` (INT, AUTO_INCREMENT, PRIMARY KEY)
- `student_id` (VARCHAR(20), FOREIGN KEY)
- `subject` (VARCHAR(100), NOT NULL)
- `grade_value` (DECIMAL(4,2), NOT NULL, CHECK 0-20)
- `grade_date` (DATE, NOT NULL)
- `created_date` (DATETIME, DEFAULT CURRENT_TIMESTAMP)
