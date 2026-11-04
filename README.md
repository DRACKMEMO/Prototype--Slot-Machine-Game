# Slot Machine Game

A simple 2D slot machine game developed in Unity using C#. This project was created as part of a game development assignment.

## Game Overview

The game is based on a classic 3-reel slot machine. The player starts with 100 credits and can use them to spin the reels.

Each spin costs 10 credits. All three reels spin and stop one by one, showing randomly selected symbols. If all three reels show the same symbol, the player wins credits according to the payout table.

## Symbols

- 7
- Cherry
- Bell
- BAR

## Payout Table

| Combination | Reward |
|---|---:|
| 7 - 7 - 7 | 100 Credits |
| Cherry - Cherry - Cherry | 50 Credits |
| Bell - Bell - Bell | 30 Credits |
| BAR - BAR - BAR | 20 Credits |

## How to Play

1. Start the game with 100 credits.
2. Press the **SPIN** button.
3. 10 credits are deducted for each spin.
4. The lever activates and the three reels start spinning one by one.
5. Wait for all reels to stop.
6. Match all three symbols to receive the corresponding reward.
7. Use the **PayTable** button to view the available rewards.

## Features

- Three spinning reels.
- Random symbol selection.
- Sequential reel animations.
- Animated lever interaction.
- Spin button interaction.
- Credit management.
- Configurable spin cost and payouts.
- Paytable UI.
- Win and loss feedback.
- Sound effects for buttons, lever and reels.

## My Approach

I divided the game into different scripts so each part handles a specific task.

### Reel System

Each reel is controlled by its own `ReelController` script. It handles the spinning animation and selects a random symbol.

The reels start one by one with a small delay to make the spinning feel more natural.

### Credit System

The `SlotMachineEconomy` script manages the player's credits. It checks whether the player has enough credits before starting a spin and deducts the spin cost.

If the player wins, the reward is added to the balance.

### Result Checking

The `SlotResultEvaluator` script checks the final symbols from all three reels.

If all three symbols match, the player receives the corresponding reward from the payout table.

### UI and Audio

The UI handles the spin button, lever, credit display and paytable.

The `SlotMachineAudio` script manages the sound effects for button clicks, lever pulls, reel spinning, reel stopping and winning.

## Running the WebGL Build

The WebGL build is available inside:

`Build/WebGL/`

Unity WebGL games should be opened through a local or web server instead of directly through `file://`.

You can use a local server to open the `index.html` file and play the game in a browser.

## Technologies Used

- Unity 6
- C#
- Unity 2D
- Unity UI
- TextMeshPro
- WebGL

## Project Structure

```text
Slot-Machine-Game/
│
├── Assets/
├── Build/
├── Library/
├── Logs/
├── Packages/
├── ProjectSettings/
├── Temp/
├── UserSettings/
│
├── .vsconfig
├── README
└── Slot Machine Game.sln
```

## Final Note

This project helped me understand how to work with Unity UI, C# scripts, coroutines, random number generation, animations and basic game logic while creating a playable slot machine game.