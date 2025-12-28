import { UserAction } from "../../../domain/enumerates/user-action";

const userActionLabelMap: Record<UserAction, string> = {
    [UserAction.MOVE_FORWARD]: "Move forward",

    [UserAction.USE_ITEM]: "Use item",
    [UserAction.USE_CURRENT_SCENE_ITEM]: "Use scene item",
    [UserAction.GET_ITEM]: "Get item",
    [UserAction.DROP_ITEM]: "Drop item",

    [UserAction.BUY_ITEMS]: "Buy items",
    [UserAction.SELL_ITEMS]: "Sell items",

    [UserAction.ATTACK_ENEMY_WITH_ITEM]: "Attack enemy with item",
    [UserAction.ATTACK_ENEMY_WITHOUT_ITEM]: "Attack enemy without item",
};

export const getLabelForUserAction = (action: UserAction): string => {
    return userActionLabelMap[action];
};
