import unittest


def roll(param):
    pass


def score():
    pass


class BowlingTestCase(unittest.TestCase):

    def test_score_is_zero_when_zero_pins_are_knocked(self):
        roll(0)
        self.assertEqual(score(), 0)
