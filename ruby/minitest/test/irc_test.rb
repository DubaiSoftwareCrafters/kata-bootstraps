require 'minitest/autorun'

class IrcTest < Minitest::Test

  def test_connect_invalid_host
    client = IrcClient.new
    assert client.is_connected
  end

end

class IrcClient

  def is_connected
    # code here
  end
end