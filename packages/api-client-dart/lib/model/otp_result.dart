//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'otp_result.g.dart';

abstract class OtpResult implements Built<OtpResult, OtpResultBuilder> {

    @BuiltValueField(wireName: r'state')
    String get state;

    OtpResult._();

    static void _initializeBuilder(OtpResultBuilder b) => b;

    factory OtpResult([void updates(OtpResultBuilder b)]) = _$OtpResult;

    @BuiltValueSerializer(custom: true)
    static Serializer<OtpResult> get serializer => _$OtpResultSerializer();
}

class _$OtpResultSerializer implements StructuredSerializer<OtpResult> {

    @override
    final Iterable<Type> types = const [OtpResult, _$OtpResult];
    @override
    final String wireName = r'OtpResult';

    @override
    Iterable<Object> serialize(Serializers serializers, OtpResult object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'state')
            ..add(serializers.serialize(object.state,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    OtpResult deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OtpResultBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'state':
                    result.state = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

