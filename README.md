# FriendFolio

FriendFolio is a digital friend book application built with ASP.NET Core Razor Pages, Entity Framework Core, and SQLite.

The idea is inspired by classic "mina vänner"-books, where people answer personal questions and leave memories, greetings, and stories. In FriendFolio, a book owner can create a digital book, add questions, share an invite link, and collect answers in one place.

## Features

- Create digital friend books
- Automatically add starter questions to new books
- Add custom questions
- Generate private invite links with invite tokens
- Let invited people submit answers without logging in
- View submitted entries and answers
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
2. Add or edit questions.
3. Share the invite link.
4. Let someone submit answers.
5. View the submitted answers as the book owner.

## Planned features

- Improve the visual design
- Add book themes
- Add optional English language support
- Add owner authentication
- Add edit/delete flows
- Add QR codes for invite links
- Add image uploads
- Export books to PDF
- Prepare for deployment

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
