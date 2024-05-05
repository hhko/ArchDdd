using DiffEngine;
using System.Runtime.CompilerServices;

namespace ArchDdd.Tests.Integration.Abstractions.VerifyInitializers;

public static class VerifierInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        //
        // .received., .verified. 파일 생성 위치
        //  - https://github.com/VerifyTests/Verify/blob/main/docs/naming.md
        //UseProjectRelativeDirectory("Snapshots");

        //
        // 데이터 범위 설정: 예. Ignore 변수, ...
        //  - https://github.com/VerifyTests/Verify/blob/main/docs/serializer-settings.md
        //VerifySourceGenerators.Enable();

        //
        // 실패 때, 파일 비교 창을 disable한다.
        //  - https://github.com/VerifyTests/DiffEngine/blob/main/docs/diff-tool.md
        DiffRunner.Disabled = true;
    }
}
