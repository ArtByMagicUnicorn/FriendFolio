# FriendFolio Roadmap

FriendFolio is a digital friendship book where users can create a book, share an invite link, and collect personal answers from friends, family, colleagues, or event guests.

## Current MVP

- Create memory books
- List created books
- View book details
- Edit book title and description
- Delete books
- Add custom questions
- Edit questions
- Delete questions
- Reorder questions
- Share invite link
- Submit answers through invite link
- Add optional photo URL to an entry
- View submitted entries
- Delete submitted entries
- Basic Swedish UI
- Local SQLite database
- EF Core migrations

## Next Steps

### 1. Improve Book Overview

Make the “Mina böcker” page feel more polished and useful.

- Improve book card layout
- Make metadata easier to scan
- Keep action buttons consistent in size
- Add clearer empty state
- Add subtle visual distinction between questions and entries

### 2. Improve Start Page

Give the start page a stronger FriendFolio identity.

- Add clearer product introduction
- Use the FriendFolio brand image
- Explain the three-step flow
- Add stronger call-to-action buttons
- Make the page feel warm, personal, and trustworthy

### 3. Add Authentication

Allow users to log in and manage their own books.

- Add login/logout
- Explore Google login
- Store the owner/user for each memory book
- Show only the logged-in user's books
- Protect create, edit, delete, and details management pages

### 4. Improve Invite Flow

Make the shared invite experience clearer and more pleasant.

- Improve invite page design
- Add preview of the book before answering
- Add better validation messages
- Add confirmation before submitting
- Make the thank-you page more personal

### 5. Better Photo Handling

Replace plain image URLs with a more user-friendly solution.

- Start with validated image URLs
- Later explore file upload
- Store images in cloud storage
- Consider Azure Blob Storage for production

### 6. Deployment

Prepare FriendFolio for hosting.

- Move connection strings and secrets out of source code
- Decide hosting option
- Prepare production database plan
- Add deployment notes
- Add GitHub Actions build workflow
- Test production-like configuration

### 7. Portfolio Preparation

Make the project presentable as a portfolio case study.

- Add screenshots
- Write project description
- Describe technical choices
- Describe what I learned
- Add GitHub link
- Add live demo link when deployed

### 8. Future Memory Emails

Let contributors choose if they want a copy of their answers emailed to them in the future.

- Add optional email field to the invite form
- Add checkbox for receiving a future copy
- Store scheduled send date
- Add email status fields
- Explore background jobs or Azure Functions for scheduled sending
- Use a mail provider such as SendGrid or Azure Communication Services

This is a later cloud feature, not part of the first MVP.