import unittest


class Game:

    def __init__(self):
        self._pins = 0

    def roll(self, pins):
        if self._pins == 10:
            self._pins += pins

        self._pins += pins

    def score(self):
        return self._pins


class BowlingTestCase(unittest.TestCase):

    def test_score_is_zero_when_zero_pins_are_knocked(self):
        game = Game()

        game.roll(0)

        self.assertEqual(0, game.score())

    def test_score_is_one_when_one_pin_is_knocked(self):
        game = Game()

        game.roll(1)

        self.assertEqual(1, game.score())

    def test_score_is_two_when_one_pin_is_knocked_in_two_rolls(self):
        game = Game()

        game.roll(1)
        game.roll(1)

        self.assertEqual(2, game.score())

    def test_score_spare_bonus(self):
        game = Game()

        game.roll(5)
        game.roll(5)
        game.roll(2)

        self.assertEqual(14, game.score())

    def test_score_spare_bonus(self):
        game = Game()

        game.roll(5)
        game.roll(5)
        game.roll(2)

        self.assertEqual(14, game.score())

        game = Game()

        game.roll(6)
        game.roll(4)
        game.roll(2)

        self.assertEqual(14, game.score())
