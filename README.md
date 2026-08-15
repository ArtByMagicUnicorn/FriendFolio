# FriendFolio

FriendFolio is a digital friend book application built with ASP.NET Core Razor Pages, Entity Framework Core, and SQLite.

The idea is inspired by classic "mina vänner"-books, where people answer personal questions and leave memories, greetings, and stories. In FriendFolio, a book owner can create a digital book, add questions, share an invite link, and collect answers in one place.

## Features

- Create digital friend books
- Automatically add starter questions to new books
- Edit book title and description
- Delete books
- Add custom questions
- Edit questions
- Delete questions
- Reorder questions
- Generate private invite links with invite tokens
- Let invited people submit answers without logging in
- Add optional photo URLs to submitted entries
- View submitted entries and answers
- Delete submitted entries
- Copy invite links to the clipboard
- Swedish user interface
- Custom FriendFolio branding and favicon
- Generate QR codes for invite links
- Google login for book owners
- User-owned books
- Protect book management pages behind login
- Allow invited guests to submit answers without logging in
- Generate QR codes for invite links

## Tech stack

- C#
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQLite
- Razor syntax
- HTML
- CSS
- Bootstrap
- JavaScript

## Current status

The core MVP flow is working:

1. A book owner logs in with Google.
2. The owner creates a digital friend book.
3. The owner adds, edits, deletes, or reorders questions.
4. The owner shares an invite link or QR code.
5. Invited guests submit answers without logging in.
6. The owner views submitted answers after logging in.
7. Books and management actions are protected by ownership checks.

## Planned features

- Improve the visual design
- Add book themes
- Add optional English language support
- Improve account management
- Explore Google login
- Add image uploads
- Explore Azure Blob Storage for uploaded images
- Add optional future memory emails
- Export books to PDF
- Prepare for deployment

## Roadmap

See [docs/roadmap.md](docs/roadmap.md) for a more detailed roadmap.

## What I am practicing

This project is used to practice building a small but complete web application with a clear data model and a real user flow.

Focus areas:

- Razor Pages page models and forms
- EF Core relationships
- SQLite database migrations
- Token-based invite links
- Basic JavaScript for browser features
- UI structure and responsive design
- Building an MVP before adding larger features

## Language

The code uses English naming conventions, while the user interface is currently in Swedish to match the nostalgic "mina vänner" concept.﻿
