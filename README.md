/RiplyCinema
├── /Components
│   ├── NavBar.cs               # Navigation bar component
│   ├── MainPanel.cs            # Main panel for dynamic content switching
├── /Forms
│   ├── MainForm.cs             # Main application form
│   ├── LoginForm.cs            # Login form
│   ├── SignupForm.cs           # Signup form
│   ├── /User
│   │   ├── UserDashboardForm.cs    # User's main dashboard
│   │   ├── MovieInfoForm.cs        # Displays detailed movie info
│   │   ├── TicketPurchaseForm.cs   # Allows ticket purchase
│   │   └── UserProfileForm.cs      # User's profile settings
│   ├── /Admin
│   │   ├── AdminDashboardForm.cs   # Admin's main dashboard
│   │   ├── MovieManagementForm.cs  # Admin panel to manage movies
│   │   └── UserManagementForm.cs   # Admin panel to manage users
├── /Models
│   ├── User.cs                # User model
│   ├── Movie.cs               # Movie model
│   ├── Ticket.cs              # Ticket model
├── /Database
│   ├── DatabaseInitializer.cs # Handles database creation and seeding
│   ├── ApplicationContext.cs  # Database context
├── /Services
│   ├── AuthService.cs         # Handles authentication
│   ├── EmailService.cs        # Sends emails
│   ├── PdfGenerator.cs        # Generates tickets in PDF
│   ├── ImageHelper.cs         # Manages image paths and loading
├── /Managers
│   ├── FormManager.cs         # Handles dynamic form switching
│   ├── RoleManager.cs         # Manages user roles and permissions
├── Program.cs                 # Entry point
