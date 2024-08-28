# TunifyDb2


## Overview

**Tunify Platform** is a music management application designed to help users:

- Organize their music libraries
- Create and manage playlists
- Enjoy a rich experience with their favorite songs, albums, and artists

Key features include user management, subscription plans, and playlist management.

## Entity Relationship Diagram (ERD)

![Tunify ERD Diagram](Tunify.png)

## Entity Relationships

### Users

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Subscription**
    - Description: Each user has a subscription type.
    - Foreign Key (FK): `Subscription_ID` (references the `Subscriptions` table)
  - **Playlists**
    - Description: Users can create multiple playlists.
    - Foreign Key (FK): `User_ID` (in the `Playlists` table)

### Subscriptions

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Users**
    - Description: A subscription type can be associated with multiple users.
    - Foreign Key (FK): `Subscription_ID` (in the `Users` table)

### Artists

- **Primary Key (PK):** `ID`
- **Relationships:**
  - **Songs**
    - Description: Artists can have multiple songs.
    - Foreign Key (FK): `Artist_ID` (in the `Songs` table)
  - **Albums**
    - Description: Artists can release multiple albums.
    - Foreign Key (FK): `Artist_ID` (in the `Albums` table)

### Albums

- **Primary Key (PK):** `ID`
- **Relationships:**
  - **Songs**
    - Description: An album can contain multiple songs.
    - Foreign Key (FK): `Album_ID` (in the `Songs` table)
  - **Artist**
    - Description: Each album is released by an artist.
    - Foreign Key (FK): `Artist_ID` (in the `Albums` table)

### Songs

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Artists**
    - Description: Each song is performed by an artist.
    - Foreign Key (FK): `Artist_ID` (in the `Songs` table)
  - **Albums**
    - Description: Each song is part of an album.
    - Foreign Key (FK): `Album_ID` (in the `Songs` table)
  - **Playlists**
    - Description: Songs can be added to multiple playlists.
    - Link Table: `PlaylistSongs`

### Playlists

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Users**
    - Description: Each playlist is created by a user.
    - Foreign Key (FK): `User_ID` (in the `Playlists` table)
  - **Songs**
    - Description: Playlists can contain multiple songs.
    - Link Table: `PlaylistSongs`

### PlaylistSongs

- **Primary Key (PK):** `Id`
- **Relationships:**
  - **Playlists**
    - Description: Links songs to a playlist.
    - Foreign Key (FK): `Playlist_ID` (references the `Playlists` table)
  - **Songs**
    - Description: Links a song to a playlist.
    - Foreign Key (FK): `Song_ID` (references the `Songs` table)


## Controllers

The TunifyPlatform uses controllers to manage incoming HTTP requests and responses. Each controller corresponds to a specific entity in the application:

- **UsersController**: Manages user-related actions, including fetching, creating, updating, and deleting users.
- **ArtistsController**: Handles requests related to artists, such as retrieving artist details and managing artist data.
- **PlaylistsController**: Deals with operations on playlists, including their creation, modification, and retrieval.
- **SongsController**: Oversees song-related functionalities, including fetching song details and updating song information.


## Repositories

Repositories abstract data access and provide a clean API for data operations. The following repositories are defined:

- **IUser**: Interface for user data operations.
- **IArtists**: Interface for artist-related data operations.
- **IPlayList**: Interface for playlist data operations.
- **ISong**: Interface for song data operations.


## Services

Services contain the business logic of the application and interact with the repositories to perform data operations:

- **UserServices**: Implements `IUser` and provides methods to manage user data.
- **ArtistsServices**: Implements `IArtists` to handle artist data management.
- **PlaylistsServices**: Implements `IPlayList` for playlist-related business logic.
- **SongServices**: Implements `ISong` to handle song data and logic.

## Swagger UI Integration

Swagger UI is included in the TunifyPlatform project to offer easy-to-use, interactive documentation for the API. It helps you explore and test the available endpoints.

### How to Access Swagger UI

1. **Start the Application**: Run the app using your preferred method (e.g., `dotnet run`, Visual Studio).

2. **Open Swagger UI**: Once running, open a web browser and go to:  
   `http://localhost:{PORT}/TunifySwagger`

## Accessing Swagger UI
Once the application is running, open your web browser and go to: `http://localhost:{PORT}/TunifySwagger`

## Setting Up Authentication with Identity
ASP.NET Core Identity is integrated into TunifyPlatform to manage user authentication, including:

- **Register:** New users can sign up with a username, email, and password using `RegisterDto`.
- **Login:** Users can log in with `LoginDto`.
- **Logout:** Users can log out, ending their session.

### How to Use:
- **Register:** Go to `/Account/Register` to create a new account.
- **Login:** Go to `/Account/Login` to sign in.
- **Logout:** Go to `/Account/Logout` to sign out.

Handle errors properly and consider logging them for troubleshooting.

## JWT Authentication and Authorization
TunifyPlatform now uses JWT for secure authentication and authorization:

- **Repository and Services:**
  - **IAccount Interface:** Updated to include JWT token generation.
  - **IdentityAccountService:** Generates JWT tokens.
  - **JwtTokenService:** Manages token creation, validation, and claims.

- **AccountController:**
  - **Login:** Now returns a JWT token with user roles and claims after successful login.

## Securing API Endpoints
- **Authorization:** Secured specific API endpoints with `[Authorize]` attributes and role-based access.

- **Roles and Claims:** 
  - Set up in authorization policies.
  - Roles and users are seeded into the database with the necessary claims.

This setup ensures secure user authentication and role-based access control in TunifyPlatform.
