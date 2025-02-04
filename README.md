
# Projet de gestion Unreal Engine

Ce programme permet de gérer les projets Unreal Engine en offrant plusieurs fonctionnalités via la ligne de commande. Vous pouvez afficher des informations sur un projet, le compiler, le packager, ou lister tous les projets Unreal sur votre disque.

## Options disponibles

Le programme accepte plusieurs options à la ligne de commande. Voici les options disponibles :

### 1. `show-infos`
Affiche les détails d'un projet à partir de son fichier `.uproject`.

**Exemple d'utilisation :**

```bash
[chemin du exe] show-infos C:/chemin/vers/ton/projet.uproject
```

### 2. `build`
Compile le projet `.uproject` avec UnrealBuildTool (UBT).

**Exemple d'utilisation :**

```bash
[chemin du exe] C:/chemin/vers/ton/projet.uproject build
```

### 3. `package`
Package le projet avec Unreal Automation Tool (UAT). Il nécessite un chemin de destination en tant que troisième argument.

**Exemple d'utilisation :**

```bash
[chemin du exe] C:/chemin/vers/ton/projet.uproject package C:/chemin/vers/le/dossier/de/destination
```

### 4. `all-projects`
Liste tous les projets Unreal Engine trouvés sur le disque. Ce mode accepte un argument optionnel pour spécifier le répertoire à partir duquel commencer la recherche (par défaut, la recherche commence à `C:/`).

**Exemple d'utilisation :**

```bash
[chemin du exe] all-projects [C:/chemin/vers/le/dossier : Optionnel]
```

## Argument `-h`

Si vous n'êtes pas sûr de ce que vous devez faire, vous pouvez passer l'argument `-h` pour afficher l'aide.

**Exemple d'utilisation :**

```bash
[chemin du exe] -h
```

### Exemple de commande complète :

```bash
[chemin du exe] all-projects
```

### Exemple avec un chemin spécifique pour la recherche :

```bash
[chemin du exe] all-projects D:/MesProjetsUnreal
```

## À propos du programme

Le programme commence par vérifier si un argument a été passé. Si aucun argument n'est donné, il affiche l'aide.

### Fonctionnement détaillé :

1. Si le premier argument est `-h`, l'aide est affichée.
2. Si le premier argument est `all-projects`, il lance une recherche de projets Unreal sur le disque à partir du répertoire spécifié (ou `C:/` par défaut).
3. Si le deuxième argument est `show-infos`, il récupère et affiche les informations d'un projet.
4. Si le deuxième argument est `build`, il compile le projet via UnrealBuildTool.
5. Si le deuxième argument est `package`, il lance le processus de packaging du projet via Unreal Automation Tool, nécessitant un troisième argument pour la destination.

## Bugs connus

La commande `all-projects` :
La commande semble ne pas trouver les **.uproject** from source
