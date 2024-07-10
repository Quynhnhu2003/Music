<-- Music Database Context -->
add-migration tên_migration -OutputDir Data/Migrations
update-database



<-- Music Identity Database Context -->
Add-Migration CreateIdentitySchema -context MusicIdentityContext -OutputDir Data/IdentityMigrations
update-database -context MusicIdentityContext 
