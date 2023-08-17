require 'minitest/autorun'

class IrcTest < Minitest::Test

  def test_connect_invalid_host
    client = IrcClient.new('invalid host')
    refute client.is_connected
  end

end

class IrcClient

  def initialize(host)
    begin
    TCPSocket.new(host,8888)
    rescue NameError
      @is_connected = false
    end
  end

  def is_connected
    @is_connected
  end
end