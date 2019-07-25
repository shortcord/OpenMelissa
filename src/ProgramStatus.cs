namespace OpenMelissa 
{
    public enum ProgramStatus {
        ErrorNone = 0,
        ErrorOther = 1,
        ErrorOutOfMemory = 2,
        ErrorRequiredFileNotFound = 3,
        ErrorFoundOldFile = 4,
        ErrorDatabaseExpired = 5,
        ErrorLicenseExpired = 6
    }
}