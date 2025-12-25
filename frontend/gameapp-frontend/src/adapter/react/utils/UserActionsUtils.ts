import { UserAction } from "../../../domain/enumerates/user-action";

export function removeUserActions(
    userActions: UserAction[],
    actionsToRemove: UserAction[]
): UserAction[] {

    return userActions.filter(action => !actionsToRemove.includes(action));
}

export function addUserActions(
    userActions: UserAction[],
    actionsToAdd: UserAction[]
): UserAction[] {

    const set = new Set(userActions);
    actionsToAdd.forEach(action => set.add(action));
    return Array.from(set);
}
