$gAwayDebug = 1;
function AWAY_DEBUG(%text)
{
    if ($gAwayDebug)
    {
        echo(%text);
    }
    return ;
    return ;
}
function serverCmdSetAfkOn(%client, %msgTagged)
{
    if (!isObject(%client.Player))
    {
        error("serverCmdSetAfkOn: null client player" SPC getDebugString(%client));
        return ;
    }
    %client.Player.setAFK(1);
    %client.Player.setAwayMessage(detag(%msgTagged));
    return ;
    return ;
}
function serverCmdSetAfkOff(%client)
{
    if (isObject(%client.Player))
    {
        %client.Player.setAFK(0);
    }
    return ;
    return ;
}
function serverCmdTypingStarted(%client)
{
    if (isObject(%client.Player))
    {
        %client.Player.setTyping(1);
    }
    return ;
    return ;
}
function serverCmdTypingFinished(%client)
{
    if (isObject(%client.Player))
    {
        %client.Player.setTyping(0);
    }
    return ;
    return ;
}
function serverCmdEtsPlayAnimName(%client, %animName)
{
    if (isObject(%client.Player))
    {
        %client.Player.playAnim(%animName);
    }
    return ;
    return ;
}
function playRandomEmote(%player)
{
    %animName = EmoteDict.getValue(getRandom(0, EmoteDict.size() - 1));
    %player.playAnim(%animName);
    return ;
    return ;
}
function Player::cardinalPosition(%this, %num)
{
    %this.setTransform("56.1625 -22.954 2.38509 0 0 -1 0.931784");
    return ;
    return ;
}
function ServerCmdCardinalPosition(%client, %num)
{
    if (isObject(%client.Player))
    {
        %client.Player.cardinalPosition(%num);
    }
    return ;
    return ;
}
function etsReloadServer()
{
    exec($userMods @ "/server/scripts/ets/init.cs");
    return ;
    return ;
}
function ServerCmdSetGenre(%client, %genre)
{
    if (!isObject(%client.Player))
    {
        return ;
    }
    %client.Player.setGenre(%genre);
    return ;
    return ;
}
