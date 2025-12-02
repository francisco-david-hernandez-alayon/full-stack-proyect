import { v4 as uuidv4 } from "uuid";

export function validateOrGenerateUUID(id) {
    const uuidRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$/i;

    if (typeof id === "string" && uuidRegex.test(id)) {
        return id; // valid UUID → keep it
    }

    return uuidv4(); // invalid or null → generate new UUID
}
