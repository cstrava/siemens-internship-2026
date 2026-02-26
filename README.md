# Siemens Internship – Technical Task (2026)

This repository contains the solution for the Siemens internship technical assignment.

## Contents

### Problem 1 (UML + ERD)
Diagrams exported from draw.io:
- `diagrams/problem1_class_diagram.png`
- `diagrams/problem1_erd.png`

### Problem 2 (C# Implementation)
A .NET 8 Console App that models orders and implements:
- (2.1) `Order` and `OrderItem` classes
- (2.2) Final order price calculation with discount rule
- (2.3) Top spender customer (sum across all orders)
- (2.4) Bonus: Popular products (total quantity sold)

## Problem 2 – Business Rules

- Each order contains one or more items (product name, quantity, unit price at purchase time).
- If an order total **exceeds 500€**, a **10% discount** is applied to the entire order.
- Top spender is computed using the **final price** (after discount).
- Popular products are aggregated by product name and total quantity sold.

## How to run

Prerequisites:
- .NET SDK 8.x

Run:
```bash
cd SieMarketTask
dotnet run
