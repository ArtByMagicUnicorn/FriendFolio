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

1. Create a book.
2. Add, edit, delete, or reorder questions.
3. Share the invite link.
4. Let someone submit answers with an optional photo URL.
5. View submitted answers as the book owner.
6. Delete test entries or books when needed.

## Planned features

- Improve the visual design
- Add book themes
- Add optional English language support
- Add owner authentication
- Explore Google login
- Add QR codes for invite links
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
