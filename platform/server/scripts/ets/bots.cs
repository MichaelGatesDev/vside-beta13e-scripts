function serverCmdAddBotArmy(%client)
{
    if (!isObject(%client.Player))
    {
        return ;
    }
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.SpawnArmyETS(%client.Player.getTransform());
    return ;
    return ;
}
function serverCmdAddBot(%client)
{
    if (!isObject(%client.Player))
    {
        return ;
    }
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.SpawnETS(%client.Player.getTransform());
    return ;
    return ;
}
function serverCmdRandomizeBots(%client)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.RandomizeBots();
    return ;
    return ;
}
function serverCmdBotsMove(%client, %val)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.BotsMove = %val;
    return ;
    return ;
}
function serverCmdToggleBotsMove(%client)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.BotsMove = !AIManager.BotsMove;
    return ;
    return ;
}
function serverCmdToggleBotsBlahBlah(%client)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.BotsBlahBlah = !AIManager.BotsBlahBlah;
    return ;
    return ;
}
function serverCmdOneShotBotsBlahBlah(%client, %toPlayer)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    if (%toPlayer)
    {
        AIManager.BotsBlahBlahOneShot(%client.Player);
    }
    else
    {
        AIManager.BotsBlahBlahOneShot();
    }
    return ;
    return ;
}
function serverCmdToggleBotsEavesdrop(%client)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.BotsEavesdrop = !AIManager.BotsEavesdrop;
    return ;
    return ;
}
function serverCmdToggleBotsSurfing(%client)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.BotsSurfing = !AIManager.BotsSurfing;
    return ;
    return ;
}
function serverCmdOneLove(%client)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    %n = 0;
    while (%n < AIManager.numBots)
    {
        AIManager.bots[%n].wardrobeStock();
        %n = %n + 1;
    }
    %client.Player.wardrobeStock();
    return ;
    return ;
}
function serverCmdZombiesAttack(%client, %position)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    if (%position $= "")
    {
        %position = %client.Player.getTransform();
    }
    AIManager.zombiesAttack(%position, %client.Player);
    return ;
    return ;
}
function serverCmdZombiesDance(%client, %param)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.zombiesDance(%param);
    return ;
    return ;
}
function serverCmdZombiesEmote(%client)
{
    if (!%client.Player.isStaff())
    {
        return ;
    }
    AIManager.zombiesEmote();
    return ;
    return ;
}
function AIManager::zombiesAttack(%this, %position, %obj)
{
    if (%this.numBots < 1)
    {
        return ;
    }
    %this.BotsMove = 0;
    %botRadius = 0.6;
    %radius = 1 + ((%botRadius * %this.numBots) / (2 * 3.14159));
    %theta = 0;
    %dTheta = (2 * 3.14159) / %this.numBots;
    %i = 0;
    while (%i < %this.numBots)
    {
        %v1 = mCos(%theta) SPC mSin(%theta) SPC 0;
        %v1 = VectorScale(%v1, %radius);
        %v1 = VectorAdd(%v1, %position);
        %this.bots[%i].zombieAttack(%v1, %position, %obj, %theta);
        %theta = %theta + %dTheta;
        %i = %i + 1;
    }
}
return ;
function AIPlayer::zombieAttack(%this, %position, %aimAt, %obj, %theta)
{
    %this.playAnim("dnc" @ getRandom(1, 2));
    %this.setMoveDestination(%position, 0);
    if (!(%obj $= ""))
    {
        %this.setAimObject(%obj);
    }
    else
    {
        %this.setAimLocation(%aimAt);
    }
    return ;
    return ;
}
function AIManager::zombiesDance(%this, %param)
{
    if (%this.numBots < 1)
    {
        return ;
    }
    %this.BotsMove = 0;
    %i = 0;
    while (%i < %this.numBots)
    {
        %this.bots[%i].playAnim("dnc" @ getRandom(1, 4));
        %i = %i + 1;
    }
}
return ;
function AIManager::zombiesEmote(%this)
{
    if (%this.numBots < 1)
    {
        return ;
    }
    %this.BotsMove = 0;
    %i = 0;
    while (%i < %this.numBots)
    {
        %this.bots[%i].doRandomEmote();
        %i = %i + 1;
    }
}
return ;
function AIPlayer::doAutoMoveEntry(%this)
{
    %this.playAnim("pwve");
    %pos = EntrySpawn.choosePointOnCenterPlane();
    %this.setAimObject(0);
    %this.schedule(2500, "setMoveDestination", %pos, 0);
    return ;
    return ;
}
function serverCmdKillBots(%client)
{
    AIManager.killBots();
    return ;
    return ;
}
function AIManager::killBots(%this)
{
    if (%this.numBots < 1)
    {
        return ;
    }
    %i = 0;
    while (%i < %this.numBots)
    {
        %this.bots[%i].delete();
        %i = %i + 1;
    }
    %this.numBots = 0;
    return ;
    return ;
}
function serverCmdBotsIdlePercent(%client, %percent)
{
    AIManager.IdleBots(%percent);
    return ;
    return ;
}
function AIManager::IdleBots(%this, %percent)
{
    %i = 0;
    while (%i < %this.numBots)
    {
        %this.bots[%i].setAFK(getRandom(1, 99) < %percent);
        %i = %i + 1;
    }
}
return ;

