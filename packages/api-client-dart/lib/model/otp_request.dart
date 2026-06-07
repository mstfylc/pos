//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'otp_request.g.dart';

abstract class OtpRequest implements Built<OtpRequest, OtpRequestBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'phone')
    String get phone;

    OtpRequest._();

    static void _initializeBuilder(OtpRequestBuilder b) => b;

    factory OtpRequest([void updates(OtpRequestBuilder b)]) = _$OtpRequest;

    @BuiltValueSerializer(custom: true)
    static Serializer<OtpRequest> get serializer => _$OtpRequestSerializer();
}

class _$OtpRequestSerializer implements StructuredSerializer<OtpRequest> {

    @override
    final Iterable<Type> types = const [OtpRequest, _$OtpRequest];
    @override
    final String wireName = r'OtpRequest';

    @override
    Iterable<Object> serialize(Serializers serializers, OtpRequest object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'phone')
            ..add(serializers.serialize(object.phone,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    OtpRequest deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OtpRequestBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'phone':
                    result.phone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

