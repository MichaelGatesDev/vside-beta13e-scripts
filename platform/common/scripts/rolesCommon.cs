function Player::hasRoleMask(%this, %mask)
{
    return roles::maskHasRole(%this.getRolesMask(), %mask);
    return ;
}
function Player::hasAnyRoleInMask(%this, %mask)
{
    return (%mask == 0) || roles::masksOverlap(%this.getRolesMask(), %mask);
    return ;
}
function Player::isStaff(%this)
{
    return %this.hasRoleString("staff");
    return ;
}
function Player::isModerator(%this)
{
    return %this.hasRoleString("moderator");
    return ;
}
function Player::isStaffOrModerator(%this)
{
    return %this.isStaff() || %this.isModerator();
    return ;
}
function Player::isCeleb(%this)
{
    return %this.hasRoleString("celeb");
    return ;
}
function Player::mayConnectToFullServer(%this)
{
    return (%this.isStaff() || %this.isModerator()) || %this.isCeleb();
    return ;
}
function Player::isDebugging(%this)
{
    %debugging = isDefined("$UserPref::ETS::Debugging") ? $UserPref::ETS::Debugging : 0;
    return %this.isStaff() && %debugging;
    return ;
}
function Player::hasRoleString(%this, %roleString)
{
    %roleBits = roleGet(%roleString);
    if (%roleBits == 0)
    {
        return 0;
    }
    return %this.hasRoleMask(%roleBits);
    return ;
}
function Player::getRoleStrings(%this)
{
    return roles::getRoleStrings(%this.getRolesMask());
    return ;
}
function Player::toggleRoleString(%this, %roleString)
{
    %roleBits = roleGet(%roleString);
    return %this.toggleRoleMask(%roleBits);
    return ;
}
function Player::toggleRoleMask(%this, %roleBits)
{
    if (%this.hasRoleMask(%roleBits))
    {
        %this.removeRoleByMask(%roleBits);
        %ret = 0;
    }
    else
    {
        %this.addRoleByMask(%roleBits);
        %ret = 1;
    }
    return %ret;
    return ;
}
function roles::masksOverlap(%maskA, %maskB)
{
    return %maskA & %maskB;
    return ;
}
function roles::maskHasRole(%mask, %roleMask)
{
    return (%mask & %roleMask) == %roleMask;
    return ;
}
function roles::maskHasRoleString(%mask, %roleString)
{
    return roles::maskHasRole(%mask, roleGet(%roleString));
    return ;
}
function roles::getRoleStrings(%mask)
{
    return rolesGetStrings(%mask);
    return ;
}
function roles::getRolesMaskFromStrings(%rolesStrings)
{
    %rolesMask = 0;
    while (!(%rolesStrings $= ""))
    {
        %rolesStrings = NextToken(%rolesStrings, "roleString", " ");
        %rolesMask = %rolesMask | roleGet(%roleString);
    }
    return %rolesMask;
    return ;
}
